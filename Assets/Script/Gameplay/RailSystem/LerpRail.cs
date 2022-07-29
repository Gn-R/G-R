using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRail : MonoBehaviour
{
    //Name normal points as Point 1, Point 2, etc. and in-between points as Point 1.5, Point 0.5, etc.
    public Transform[] points;
    //Speed of all movement including rotation
    public float speedModifier = 0.5f;
    //Which index the player is on
    public int currPoint = 0;
    //If the player can continue inputting operations
    public bool canMove = true;

    //Main camera that the player sees
    public Camera mainCam;

    //Used to stop and start operations
    private Coroutine travel = null;
    private Coroutine rotation = null;
    private Coroutine camMove = null;
    private Coroutine keyDelay = null;

    private void Update()
    {
        //If right arrow pressed and there's been sufficient time and can move, travel to next point
        if (canMove && keyDelay == null && Manager.Instance.forward == true)
        {
            //Must be within index
            if (currPoint < points.Length - 1)
            {
                currPoint++;
            }
            else
            {
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
            Manager.Instance.forward = false;
        }
        //Same as above but for going left
        else if (canMove && keyDelay == null && Manager.Instance.back == true)
        {
            //Must be within index
            if (currPoint > 0)
            {
                currPoint--;
            }
            else
            {
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
            Manager.Instance.back = false;
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
        if (currPoint < 0 || currPoint >= points.Length)
        {
            yield break;
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

            tParam += Time.deltaTime * speedModifier;
            
            transform.position = Vector3.SmoothDamp(transform.position, point.position, ref vel, speedModifier);

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
        }
    }

    //Rotates camera to rotation of the CamPos child
    private IEnumerator RotateCam(Quaternion rot)
    {
        rot = Quaternion.Euler(mainCam.transform.rotation.eulerAngles.x, rot.eulerAngles.y, mainCam.transform.rotation.eulerAngles.z);
        while (Quaternion.Angle(mainCam.transform.rotation, rot) > 0.01)
        {
            mainCam.transform.rotation = Quaternion.Lerp(mainCam.transform.rotation, rot, Time.deltaTime * speedModifier * 5f);

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
            tParam += Time.deltaTime * speedModifier;

            mainCam.transform.localPosition = Vector3.SmoothDamp(mainCam.transform.localPosition, pos, ref vel, speedModifier);

            yield return new WaitForFixedUpdate();
        }

        mainCam.transform.localPosition = pos;
        camMove = null;
    }
}
