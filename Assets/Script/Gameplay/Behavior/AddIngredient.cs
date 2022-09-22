using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIngredient : MonoBehaviour
{

    Ray camRay;
    RaycastHit hitInfo;
    public float x;
    public float y;
    public float z;
    private Vector3 direction;
    private Vector3 bowlPos;
    private Vector3 offset;
    private Vector3 randomPosition;

    public GameObject pointpos;
    public Canvas UI;
    public GameObject[] inge;
    public GameObject[] pointtype;

    public AudioSource Add;
    public AudioSource Mix;

    public GameObject manager;

    public Transform ingredientParent;

    private void Start()
    {
        bowlPos = transform.position;
        offset = new Vector3(0, 1, 0);
       // offsetmore = new Vector3(0, 2, 0);
        //offsetp = new Vector3(1, 0, 0);
        Manager.Instance.combo = new List<string>();

        //var randomPosition = Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z) );

        randomPosition = new Vector3(0, 1, 0);

        Add.GetComponents<AudioSource>();
        Mix.GetComponents<AudioSource>();

    }
    void Update()
    {
        bowlPos = transform.position;
        
        if (!Manager.Instance.paused && !Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(camRay.origin, camRay.direction * 100, Color.red);

            x = Input.mousePosition.x;
            y = Input.mousePosition.y;
            z = Input.mousePosition.z;

            direction = new Vector3(x, y, z);

            if (Physics.Raycast(camRay, out hitInfo, float.MaxValue) && Input.GetMouseButtonDown(0))
            {
                // Debug.Log(hitInfo.transform.name);
                
                switch(hitInfo.transform.name)
                {
                    // TODO use dictionary/set to look up ingredient names
                    case "Brown":
                        InstantiateIngredient();
                        AddToCombo("Green", 10);
                        break;

                    case "Roots":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Chickp":
                        InstantiateIngredient();
                        AddToCombo("Blue", 10);
                        break;

                    case "Broccoli":
                        InstantiateIngredient();
                        AddToCombo("Green", 10);
                        break;

                    case "Cannellinib":
                        InstantiateIngredient();
                        AddToCombo("Blue", 10);
                        break;

                    case "Beets":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;
                    
                    case "Sweetp":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Blackb":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);                        
                        break;

                    case "Corn":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Cucumber":
                        InstantiateIngredient();
                        AddToCombo("Green", 10);
                        break;

                    case "Onion":
                        InstantiateIngredient();
                        AddToCombo("Blue", 10);
                        break;

                    case "Tomatoes":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;
                    
                    case "Feta":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;
                    
                    case "Parmesan":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Avocado":
                        InstantiateIngredient();
                        AddToCombo("Green", 10);
                        break;

                    case "Chips":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Lime":
                        InstantiateIngredient();
                        AddToCombo("Green", 10);
                        break;

                    case "Egg":
                        InstantiateIngredient();
                        AddToCombo("R", 10);
                        break;
                    
                    case "Cheddar":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Pickled_o":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Jalapeno":
                        InstantiateIngredient();
                        AddToCombo("Green", 10);
                        break;

                    case "Red_Cab":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Goat":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Pine":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;
                    
                    case "Carrots":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Tofu":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "Chicken":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "B1":
                        InstantiateIngredient();
                        AddToCombo("Red", 10);
                        break;

                    case "B2":
                        InstantiateIngredient();
                        AddToCombo("Green", 10);
                        break;

                    case "B3":
                        InstantiateIngredient();
                        AddToCombo("Blue", 10);
                        break;

                    case "B4":
                        InstantiateIngredient();
                        AddToCombo("Blue", 10);
                        break;

                    case "B5":
                        InstantiateIngredient();
                        AddToCombo("Blue", 10);
                        break;

                    case "B6":
                        InstantiateIngredient();
                        AddToCombo("Blue", 10);
                        break;

                    case "MainBowl":
                        if (Manager.Instance.Mixing == false)
                        {
                            Instantiate(pointtype[1], pointpos.transform.position, Quaternion.Euler(0, 0, 45), UI.transform);
                            //Manager.Instance.Score += 100;
                            manager.GetComponent<DishManager>().mixBowl(false);
                            manager.GetComponent<LerpRail>().advanceStopPoint();

                            if (manager.GetComponent<DishManager>().checkMix(Manager.Instance.combo))
                            {
                                Manager.Instance.Score += 100;
                            }
                            else
                            {
                                Manager.Instance.Score -= 100;
                            }
                        }
                        Manager.Instance.Mixing = true;
                        Mix.Play();
                        break;

                    default:
                        break;
                }

            }
        }
    }

    private void InstantiateIngredient()
    {
        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
        Instantiate(inge[0], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
        Instantiate(pointtype[0], pointpos.transform.position, Quaternion.Euler(0, 0, 0), UI.transform);
    }

    private void AddToCombo(string name, int points)
    {
        Manager.Instance.Score += points;
        Manager.Instance.combo.Add(name);
        Add.Play();
    }
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