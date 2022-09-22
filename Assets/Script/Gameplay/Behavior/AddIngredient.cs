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
    public GameObject rails;
    private Transform railPoint; // make this global

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
                railPoint = rails.GetComponent<LerpRail>().points[rails.GetComponent<LerpRail>().currPoint].GetChild(1);
                
                switch(hitInfo.transform.name)
                {
                    // TODO use dictionary/set to look up ingredient names?
                    case "Brown":
                        InstantiateIngredient(0, true);
                        AddToCombo("Brown Rice", 10);
                        break;

                    case "Roots":
                        InstantiateIngredient(1, true);
                        AddToCombo("Roots Rice", 10);
                        break;

                    case "Chickp":
                        InstantiateIngredient(2, false);
                        AddToCombo("Chickpeas", 10);
                        break;

                    case "Broccoli":
                        InstantiateIngredient(3, false);
                        AddToCombo("Broccoli", 10);
                        break;

                    case "Cannellinib":
                        InstantiateIngredient(4, false);
                        AddToCombo("Cannellini Beans", 10);
                        break;

                    case "Beets":
                        InstantiateIngredient(5, false);
                        AddToCombo("Roasted Beets", 10);
                        break;
                    
                    case "Sweetp":
                        InstantiateIngredient(6, false);
                        AddToCombo("Sweet Potatoes", 10);
                        break;

                    case "Blackb":
                        InstantiateIngredient(7, false);
                        AddToCombo("Black Beans", 10);                        
                        break;

                    case "bulgar":
                        InstantiateIngredient(8, false);
                        AddToCombo("Bulgur", 10);
                        break;

                    case "Corn":
                        InstantiateIngredient(9, false);
                        AddToCombo("Charred Corn", 10);
                        break;

                    case "Cucumber":
                        InstantiateIngredient(10, false);
                        AddToCombo("Cucumber", 10);
                        break;

                    case "Onion":
                        InstantiateIngredient(11, false);
                        AddToCombo("Red Onions", 10);
                        break;

                    case "Tomatoes":
                        InstantiateIngredient(12, false);
                        AddToCombo("Grape Tomatoes", 10);
                        break;
                    
                    case "Feta":
                        InstantiateIngredient(13 ,false);
                        AddToCombo("Feta", 10);
                        break;
                    
                    case "Parmesan":
                        InstantiateIngredient(14, false);
                        AddToCombo("Shaved Parmesan", 10);
                        break;

                    case "Avocado":
                        InstantiateIngredient(15 ,false);
                        AddToCombo("Avocado", 10);
                        break;

                    case "Chips":
                        InstantiateIngredient(16, false);
                        AddToCombo("Pita Chips", 10);
                        break;

                    case "Lime":
                        InstantiateIngredient(17, false);
                        AddToCombo("Cilantro Lime", 10);
                        break;

                    case "Egg":
                        InstantiateIngredient(18, false);
                        AddToCombo("Hard Boiled Egg", 10);
                        break;
                    
                    case "Cheddar":
                        InstantiateIngredient(19, false);
                        AddToCombo("Cheddar", 10);
                        break;

                    case "Pickled_o":
                        InstantiateIngredient(20, false);
                        AddToCombo("Lime-Pickled Onions", 10);
                        break;

                    case "Jalapeno":
                        InstantiateIngredient(21, false);
                        AddToCombo("Pickled Jalapenos", 10);
                        break;

                    case "Red_Cab":
                        InstantiateIngredient(22, false);
                        AddToCombo("Red Cabbage", 10);
                        break;

                    case "Goat":
                        InstantiateIngredient(23, false);
                        AddToCombo("Goat Cheese", 10);
                        break;

                    case "Pine":
                        InstantiateIngredient(24, false);
                        AddToCombo("Pineapple", 10);
                        break;
                    
                    case "Carrots":
                        InstantiateIngredient(25, false);
                        AddToCombo("Carrots", 10);
                        break;

                    case "Tofu":
                        InstantiateIngredient(26, false);
                        AddToCombo("Tofu", 10);
                        break;

                    case "Chicken":
                        InstantiateIngredient(27, false);
                        AddToCombo("Chicken", 10);
                        break;

                    // TODO add names and indices for bottles
                    case "B1":
                        InstantiateIngredient(0, false);
                        AddToCombo("B1", 10);
                        break;

                    case "B2":
                        InstantiateIngredient(0, false);
                        AddToCombo("B2", 10);
                        break;

                    case "B3":
                        InstantiateIngredient(0, false);
                        AddToCombo("B3", 10);
                        break;

                    case "B4":
                        InstantiateIngredient(0, false);
                        AddToCombo("B4", 10);
                        break;

                    case "B5":
                        InstantiateIngredient(0, false);
                        AddToCombo("B5", 10);
                        break;

                    case "B6":
                        InstantiateIngredient(0, false);
                        AddToCombo("B6", 10);
                        break;

                    case "MainBowl":
                        if (Manager.Instance.Mixing == false)
                        {
                            // NEW added rail stuff to bowl
                            Instantiate(pointtype[1], railPoint.transform.position, railPoint.transform.rotation, UI.transform);
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
                }

            }
        }
    }

    private void InstantiateIngredient(int index, bool randomize)
    {
        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
        if (randomize)
        {
            // NEW Added ingredient index and randomize position options
            for (int i = 0; i < 5; i++)
            {
                //Used to offset ingredients to instantiate into bowl
                Vector3 randomOffset = new Vector3(Random.Range(-0.09f, 0.1f), Random.Range(-0.2f, 0.2f), Random.Range(-0.175f, 0.05f));
                Instantiate(inge[index], bowlPos + offset + randomOffset, Quaternion.Euler(0, 0, 0), ingredientParent);
            }
        }
        else
        {
            // Instantiate(inge[0], bowlPos + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
            Instantiate(pointtype[0], railPoint.transform.position , railPoint.transform.rotation, UI.transform);
        }
    }
    
    // NEW added dish manager stuff to combo and updated name parameters in method calls
    private void AddToCombo(string name, int points)
    {
        Manager.Instance.Score += points;
        Manager.Instance.combo.Add(name);
        Add.Play();

        
        if (manager.GetComponent<DishManager>().requiresExtra(name))
        {
            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar(name));
        }
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