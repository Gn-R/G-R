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

    private void Update()
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
                railPoint = manager.GetComponent<LerpRail>().points[manager.GetComponent<LerpRail>().currPoint].GetChild(1);
                
                switch(hitInfo.transform.name)
                {
                    // TODO use dictionary/set to look up ingredient names?
                    case "Brown":
                        InstantiateIngredient(0, true, 5);
                        AddToCombo("Brown Rice", 10);
                        break;

                    case "Roots":
                        InstantiateIngredient(1, true, 5);
                        AddToCombo("Roots Rice", 10);
                        break;

                    case "Chickp":
                        InstantiateIngredient(2, true, 1);
                        AddToCombo("Chickpeas", 10);
                        break;

                    case "Broccoli":
                        InstantiateIngredient(3, true, 1);
                        AddToCombo("Broccoli", 10);
                        break;

                    case "Cannellinib":
                        InstantiateIngredient(4, true, 1);
                        AddToCombo("Cannellini Beans", 10);
                        break;

                    case "Beets":
                        InstantiateIngredient(5, true, 1);
                        AddToCombo("Roasted Beets", 10);
                        break;
                    
                    case "Sweetp":
                        InstantiateIngredient(6, true, 1);
                        AddToCombo("Sweet Potatoes", 10);
                        break;

                    case "Blackb":
                        InstantiateIngredient(7, true, 1);
                        AddToCombo("Black Beans", 10);                        
                        break;

                    case "Bulgar":
                        InstantiateIngredient(8, true, 1);
                        AddToCombo("Bulgur", 10);
                        break;

                    case "Corn":
                        InstantiateIngredient(9, true, 1);
                        AddToCombo("Charred Corn", 10);
                        break;

                    case "Cucumber":
                        InstantiateIngredient(10, true, 1);
                        AddToCombo("Cucumber", 10);
                        break;

                    case "Onion":
                        InstantiateIngredient(11, true, 1);
                        AddToCombo("Red Onions", 10);
                        break;

                    case "Tomatoes":
                        InstantiateIngredient(12, true, 1);
                        AddToCombo("Grape Tomatoes", 10);
                        break;
                    
                    case "Feta":
                        InstantiateIngredient(13, true, 1);
                        AddToCombo("Feta", 10);
                        break;
                    
                    case "Parmesan":
                        InstantiateIngredient(14, true, 1);
                        AddToCombo("Shaved Parmesan", 10);
                        break;

                    case "Avocado":
                        InstantiateIngredient(15, true, 1);
                        AddToCombo("Avocado", 10);
                        break;

                    case "Chips":
                        InstantiateIngredient(16, true, 1);
                        AddToCombo("Pita Chips", 10);
                        break;

                    case "Lime":
                        InstantiateIngredient(17, true, 1);
                        AddToCombo("Cilantro Lime", 10);
                        break;

                    case "Egg":
                        InstantiateIngredient(18, true, 1);
                        AddToCombo("Hard Boiled Egg", 10);
                        break;
                    
                    case "Cheddar":
                        InstantiateIngredient(19, true, 1);
                        AddToCombo("Cheddar", 10);
                        break;

                    case "Pickled_o":
                        InstantiateIngredient(20, true, 1);
                        AddToCombo("Lime-Pickled Onions", 10);
                        break;

                    case "Jalapeno":
                        InstantiateIngredient(21, true, 1);
                        AddToCombo("Pickled Jalapenos", 10);
                        break;

                    case "Red_Cab":
                        InstantiateIngredient(22, true, 1);
                        AddToCombo("Red Cabbage", 10);
                        break;

                    case "Goat":
                        InstantiateIngredient(23, true, 1);
                        AddToCombo("Goat Cheese", 10);
                        break;

                    case "Pine":
                        InstantiateIngredient(24, true, 1);
                        AddToCombo("Pineapple", 10);
                        break;
                    
                    case "Carrots":
                        InstantiateIngredient(25, true, 1);
                        AddToCombo("Carrots", 10);
                        break;

                    case "Tofu":
                        InstantiateIngredient(26, true, 1);
                        AddToCombo("Tofu", 10);
                        break;

                    case "Chicken":
                        InstantiateIngredient(27, true, 1);
                        AddToCombo("Chicken", 10);
                        break;

                    // TODO add names and indices for bottles
                    case "B1":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, true, 1);
                        AddToCombo("B1", 10);
                        break;

                    case "B2":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, true, 1);
                        AddToCombo("B2", 10);
                        break;

                    case "B3":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, true, 1);
                        AddToCombo("B3", 10);
                        break;

                    case "B4":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, true, 1);
                        AddToCombo("B4", 10);
                        break;

                    case "B5":
                        AnimateBottle(hitInfo.transform.gameObject);
                        InstantiateIngredient(0, true, 1);
                        AddToCombo("B5", 10);
                        break;

                    case "B6":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, true, 1);
                        AddToCombo("B6", 10);
                        break;

                    case "MainBowl":
                        if (Manager.Instance.Mixing == false)
                        {
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

    private void InstantiateIngredient(int index, bool randomize, int count)
    {
        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
        if (randomize)
        {
            for (int i = 0; i < count; i++)
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

    private void AnimateBottle(GameObject obj)
    {
        BottleAnime anim = obj.GetComponent<BottleAnime>();
        anim.OnBottleClick();
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