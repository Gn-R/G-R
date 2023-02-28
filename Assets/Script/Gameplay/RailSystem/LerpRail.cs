using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpRail : MonoBehaviour
{
    //Name normal points as Point 1, Point 2, etc. and in-between points as Point 1.5, Point 0.5, etc.
    public Transform[] points;
    //The points the player can not progress past without mixing
    public int[] stopPoints;
    public int currStop = 0;

    //Gray out the buttons if they are blocked
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject rightMixFirstUI;

    //Speed of movement 
    public float moveSpeedModifier = 0.5f;
    //Speed of camera
    public float camSpeedModifier = 0.5f;
    //Which index the player is on
    public int currPoint = 0;
    //If the player can continue inputting operations
    public bool canMove = true;

    //Main camera that the player sees
    public Camera mainCam;

    //Used to stop and start operations
    public Coroutine travel = null;
    private Coroutine rotation = null;
    private Coroutine camMove = null;
    private Coroutine keyDelay = null;
    private Coroutine returnCo = null;

    public GameObject manager;
    public GameObject prompts;

    private void Update()
    {
        //If right arrow pressed and there's been sufficient time and can move, travel to next point
        if (canMove && keyDelay == null && Manager.Instance.right == true && !Manager.Instance.discarding && (stopPoints.Length <= 0 || currPoint != stopPoints[currStop]))
        {
            //Must be within index
            if (currPoint < points.Length - 1)
            {
                currPoint++;
            }
            else
            {
                Manager.Instance.right = false;
                return;
            }

            //Travels to next point
            if (travel != null)
            {
                StopCoroutine(travel);
            }
            travel = StartCoroutine(Travel(true));

            //Prevents accidental double presses
            if (keyDelay != null)
            {
                StopCoroutine(keyDelay);
            }
            keyDelay = StartCoroutine(KeyDelay());

            //Manages arrow input
            Manager.Instance.right = false;
        }
        //Same as above but for going left
        else if (canMove && keyDelay == null && Manager.Instance.left == true && !Manager.Instance.discarding)
        {
            //Must be within index
            if (currPoint > 0)
            {
                currPoint--;
            }
            else
            {
                Manager.Instance.left = false;
                return;
            }

            //Travels to next point
            if (travel != null)
            {
                StopCoroutine(travel);
            }
            travel = StartCoroutine(Travel(false));

            //Prevents accidental double presses
            if (keyDelay != null)
            {
                StopCoroutine(keyDelay);
            }
            keyDelay = StartCoroutine(KeyDelay());

            //Manages arrow input
            Manager.Instance.left = false;
        }

        Manager.Instance.right = false;
        Manager.Instance.left = false;
    }

    public bool isAtEnd()
    {
        return currPoint >= points.Length - 1;
    }

    public void advanceStopPoint()
    {
        if (currStop < stopPoints.Length - 1)
        {
            currStop++;
        }
        rightMixFirstUI.SetActive(false);


        if (stopPoints.Length > 0 && stopPoints[currStop] == currPoint && currPoint < points.Length)
        {
            if (DishManager.mixes < 3)
                rightMixFirstUI.SetActive(true);
            SetButtonBlocked(rightButton, true);
        }
        else
        {
            SetButtonBlocked(rightButton, false);
        }
    }


    //Adds delay to key presses (so rails are not skipped when close to each other)
    private IEnumerator KeyDelay()
    {
        yield return new WaitForSeconds(0.5f);
        keyDelay = null;
    }

    //Uses SmoothDamp() to travel to the next point
    //If the current point ends with ".5" automatically travel to the next point
    private IEnumerator Travel(bool moveRight)
    {
        prompts.GetComponent<TutorialPrompts>().onPointUpdate(currPoint);

        if (currPoint < 0 || currPoint >= points.Length)
        {
            travel = null;
            yield break;
        }

        if (stopPoints.Length > 0 && stopPoints[currStop] == currPoint && currPoint < points.Length)
        {
            if (DishManager.mixes < 3) 
                rightMixFirstUI.SetActive(true);
            SetButtonBlocked(rightButton, true);
        }
        else if (currPoint >= points.Length - 1)
        {
            SetButtonBlocked(rightButton, true);
        }
        else
        {
            rightMixFirstUI.SetActive(false);
            SetButtonBlocked(rightButton, false);
        }

        if (currPoint <= 0)
        {
            SetButtonBlocked(leftButton, true);
        } 
        else
        {
            SetButtonBlocked(leftButton, false);
        }

        Transform point = points[currPoint];
        //How close the bowl needs to be to the set destination (more accurate for normal points, less accurate for in-between)
        float accuracy = 0.025f;
        //In-between represent .5 points to travel past automatically
        bool inBetween = false;

        if (point.name.EndsWith(".5"))
        {
            accuracy = 0.25f;
            inBetween = true;
        }

        //Rotate camera using the point's child's transform
        if (rotation != null)
        {
            StopCoroutine(rotation);
        }
        if (point.childCount > 0)
        {
            rotation = StartCoroutine(RotateCam(point.GetChild(0).rotation));
        }

        //Moves camera using the point's child's transform
        if (camMove != null)
        {
            StopCoroutine(camMove);
        }
        if (point.childCount > 0)
        {
            camMove = StartCoroutine(MoveCam(point.GetChild(0).localPosition));
        }

        canMove = false;

        float tParam = 0;
        Vector3 vel = Vector3.zero;
        while (Vector3.Distance(transform.position, point.position) > accuracy)
        {
            //Allows movement before reaching destination for input fluidity
            if (Vector3.Distance(transform.position, point.position) < 1f && !inBetween)
            {
                canMove = true;
            }

            tParam += Time.deltaTime * moveSpeedModifier;
            
            transform.position = Vector3.SmoothDamp(transform.position, point.position, ref vel, moveSpeedModifier);

            //FixedUpdate standardizes speed across framerates
            yield return new WaitForFixedUpdate();
        }

        canMove = true;

        //If an in-between (.5) point, automatically move to the point after it
        if (moveRight && inBetween)
        {
            currPoint++;
            if (travel != null)
            {
                StopCoroutine(travel);
            }

            travel = StartCoroutine(Travel(true));
        }
        else if (inBetween)
        {
            currPoint--;
            if (travel != null)
            {
                StopCoroutine(travel);
            }

            travel = StartCoroutine(Travel(false));
        }
        else
        {
            travel = null;
            yield break;
        }
    }

    //Rotates camera to rotation of the CamPos child
    private IEnumerator RotateCam(Quaternion rot)
    {
        rot = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, rot.eulerAngles.z);
        while (Quaternion.Angle(mainCam.transform.rotation, rot) > 0.01)
        {
            mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation, rot, Time.deltaTime * 1/camSpeedModifier * 1.5f);

            yield return new WaitForFixedUpdate();
        }

        mainCam.transform.rotation = rot;

        rotation = null;
    }

    //Moves camera to position of the CamPos child
    private IEnumerator MoveCam(Vector3 pos)
    {
        float tParam = 0;
        Vector3 vel = Vector3.zero;
        while (Vector3.Distance(mainCam.transform.localPosition, pos) > 0.025f)
        {
            tParam += Time.deltaTime * camSpeedModifier;

            mainCam.transform.localPosition = Vector3.SmoothDamp(mainCam.transform.localPosition, pos, ref vel, camSpeedModifier);

            yield return new WaitForFixedUpdate();
        }

        mainCam.transform.localPosition = pos;
        camMove = null;
    }

    public void returnToStart()
    {
        if (returnCo != null)
        {
            StopCoroutine(returnCo);
        }
        returnCo = StartCoroutine(Return());
        currStop = 0;
    }

    private IEnumerator Return()
    {

        while (currPoint != 1)
        {
            if (currPoint > 1 && canMove)
            {
                currPoint--;
                if (travel != null)
                {
                    StopCoroutine(travel);
                }
                travel = StartCoroutine(Travel(false));
            }
            else if (canMove)
            {
                currPoint++;
                if (travel != null)
                {
                    StopCoroutine(travel);
                }
                travel = StartCoroutine(Travel(true));
            }

            yield return new WaitForSeconds(0.1f);
        }

        returnCo = null;
    }

    public Transform GetCurrentPoint()
    {
        return points[currPoint];
    }

    private void SetButtonBlocked(GameObject button, bool blocked)
    {
        Image image = button.GetComponent<Image>();
        if (blocked)
        {
            image.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            image.color = new Color(1f, 1f, 1f);
        }
    }
}