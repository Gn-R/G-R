using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A script that allows the user to add ingredients to their bowl
// Checks the user's bowl against the recipe to follow
// Affects if score is added or detracted
public class Add_inge : MonoBehaviour
{

    Ray camRay;
    RaycastHit hitInfo;
    public float x;
    public float y;
    public float z;
    private Vector3 direction;
    private Vector3 bowlPos;
    private Vector3 offset;
    private Vector3 offsetp;
    public GameObject[] pointpos;
    public Canvas UI;
    public GameObject[] inge;
    public GameObject[] pointtype;

    public AudioSource Add;
    public AudioSource Mix;

    private List<string> currentRecipe; // which recipe to follow
    private List<string> combo; // user added ingredients
    private int ingeIndex; // which ingredient to add

    private void Start()
    {
        bowlPos = transform.position;
        offset = new Vector3(0, 1, 0);
        //offsetp = new Vector3(1, 0, 0);

        currentRecipe = Recipes.balancedDiet; // TODO create set recipe method or get current recipe from Manager
        
        Manager.Instance.combo = new List<string>(); // user added ingredients
        combo = Manager.Instance.combo; // reference to manager field
        ingeIndex = 0;

        Add.GetComponents<AudioSource>();
        Mix.GetComponents<AudioSource>();
        
    }
    void Update()
    {
        if (Manager.Instance.Mixing == false && Manager.Instance.discarding == false)
        {
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(camRay.origin, camRay.direction * 100, Color.red);

            x = Input.mousePosition.x;

            y = Input.mousePosition.y;

            z = Input.mousePosition.z;

            direction = new Vector3(x, y, z);


            if (Physics.Raycast(camRay, out hitInfo, float.MaxValue))
            {
                if (hitInfo.transform.name == "Well2" | hitInfo.transform.name == "ing1")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[0], bowlPos + offset, Quaternion.Euler(0, 0, 0));
                        AddIngredient("Green");
                    }

                }
                else if (hitInfo.transform.name == "Well3" | hitInfo.transform.name == "ing2")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[1], bowlPos + offset, Quaternion.Euler(0, 0, 0));
                        AddIngredient("Red");
                    }

                }
                else if (hitInfo.transform.name == "Well5" | hitInfo.transform.name == "ing3")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
                        Instantiate(inge[2], bowlPos + offset, Quaternion.Euler(0, 0, 0));
                        AddIngredient("Blue");
                    }

                }
                else if (hitInfo.transform.name == "MainBowl")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if(Manager.Instance.Mixing == false)
                        {
                            Instantiate(pointtype[1], pointpos[3].transform.position, Quaternion.Euler(0, 0, 45), UI.transform);
                            Manager.Instance.Score += 100;
                        }
                        Manager.Instance.Mixing = true;
                        Mix.Play();
                    }

                }
            }
        }
    }

    public void AddIngredient(string inge)
    {
        combo.Add(inge);
        // Manager.Instance.combo.Add(inge);
        if (ingeIndex < currentRecipe.Count)
        {
            // TODO see if there is string equals ignore case method
            if (inge.ToLower().Equals(currentRecipe[ingeIndex].ToLower())) // right ingredient
            {
                Manager.Instance.Score += 10;
                Instantiate(pointtype[0], pointpos[1].transform.position, Quaternion.Euler(0, 0, 0), UI.transform);
                Add.Play();
            }
            else // wrong ingredient
            {
                Manager.Instance.Score -= 10;
                // TODO play failure noise
                // TODO create -10 particle
            }
        }
        else  // too many ingredients
        {
            Manager.Instance.Score -= 10;
        }

        ingeIndex++;
        
    }

    // TODO clear bowl method
}


//if (Manager.Instance.IsLaunched == false)
//{
//    //screenray = Camera.main.ScreenPointToRay(Input.mousePosition);

//    x = UltimateJoystick.GetHorizontalAxis("Joy");

//    z = UltimateJoystick.GetVerticalAxis("Joy");

//    //Debug.DrawRay(screenray.origin, screenray.direction * 100, Color.red);

//    //if (Physics.Raycast(screenray, out hitInfo, float.MaxValue))
//    //{

//    //if (hitInfo.transform.name == "Plane")
//    //{
//    Direction = new Vector3(x, 0, z) * 100f;
//    //Debug.Log(Direction);
//    if (Direction.magnitude > 0.5)
//    {
//        Manager.Instance.Direction = Direction;
//        Manager.Instance.UIPoint = Direction;
//    }
//    //}
//    //}

//    //Debug.DrawRay(shiporigin, directions * 100, Color.yellow);
//    Manager.Instance.ShipPos = ShipOrigin;