using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO move this script to MBP object and fix prefab position and size
public class AddIngredient : MonoBehaviour
{

    public GameObject pointpos;
    public Canvas UI;
    public Button mixButton;
    public GameObject[] inge;
    public GameObject[] pointtype;

    public AudioSource Add;
    public AudioSource Mix;

    public GameObject manager;
    // public Transform bowl;

    private Vector3 offset;
    private Vector3 randomPosition;
    private Transform railPoint;

    private Ray camRay;
    private RaycastHit hitInfo;

    public Transform ingredientParent;

    private void Start()
    {
        Manager.Instance.combo = new List<string>();
        mixButton.onClick.AddListener(MixBowl);

        offset = new Vector3(0, 1, 0);
        randomPosition = new Vector3(0, 1, 0);

        Add.GetComponents<AudioSource>();
        Mix.GetComponents<AudioSource>();
    }

    private void Update()
    {      
        Vector3 bowlPos = transform.position;
        
        if (!Manager.Instance.paused && !Manager.Instance.Mixing && !Manager.Instance.discarding)
        {
            camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(camRay.origin, camRay.direction * 100, Color.red);

            if (Physics.Raycast(camRay, out hitInfo, float.MaxValue) && Input.GetMouseButtonDown(0))
            {
                railPoint = manager.GetComponent<LerpRail>().points[manager.GetComponent<LerpRail>().currPoint].GetChild(1);
                
                switch(hitInfo.transform.name)
                {
                    // Define all the raycastable ingredients
                    // TODO use dictionary/set to look up ingredient names?
                    case "Brown":
                        InstantiateIngredient(0, bowlPos, true, 5);
                        AddToCombo("Brown Rice", 10);
                        break;

                    case "Roots":
                        InstantiateIngredient(1, bowlPos, true, 5);
                        AddToCombo("Roots Rice", 10);
                        break;

                    case "Chickp":
                        InstantiateIngredient(2, bowlPos, true, 1);
                        AddToCombo("Chickpeas", 10);
                        break;

                    case "Broccoli":
                        InstantiateIngredient(3, bowlPos, true, 1);
                        AddToCombo("Broccoli", 10);
                        break;

                    case "Cannellinib":
                        InstantiateIngredient(4, bowlPos, true, 1);
                        AddToCombo("Cannellini Beans", 10);
                        break;

                    case "Beets":
                        InstantiateIngredient(5, bowlPos, true, 1);
                        AddToCombo("Roasted Beets", 10);
                        break;
                    
                    case "Sweetp":
                        InstantiateIngredient(6, bowlPos, true, 1);
                        AddToCombo("Sweet Potatoes", 10);
                        break;

                    case "Blackb":
                        InstantiateIngredient(7, bowlPos, true, 1);
                        AddToCombo("Black Beans", 10);                        
                        break;

                    case "Bulgar":
                        InstantiateIngredient(8, bowlPos, true, 1);
                        AddToCombo("Bulgur", 10);
                        break;

                    case "Corn":
                        InstantiateIngredient(9, bowlPos, true, 1);
                        AddToCombo("Charred Corn", 10);
                        break;

                    case "Cucumber":
                        InstantiateIngredient(10, bowlPos, true, 1);
                        AddToCombo("Cucumber", 10);
                        break;

                    case "Onion":
                        InstantiateIngredient(11, bowlPos, true, 1);
                        AddToCombo("Red Onions", 10);
                        break;

                    case "Tomatoes":
                        InstantiateIngredient(12, bowlPos, true, 1);
                        AddToCombo("Grape Tomatoes", 10);
                        break;
                    
                    case "Feta":
                        InstantiateIngredient(13, bowlPos, true, 1);
                        AddToCombo("Feta", 10);
                        break;
                    
                    case "Parmesan":
                        InstantiateIngredient(14, bowlPos, true, 1);
                        AddToCombo("Shaved Parmesan", 10);
                        break;

                    case "Avocado":
                        InstantiateIngredient(15, bowlPos, true, 1);
                        AddToCombo("Avocado", 10);
                        break;

                    case "Chips":
                        InstantiateIngredient(16, bowlPos, true, 1);
                        AddToCombo("Pita Chips", 10);
                        break;

                    case "Lime":
                        InstantiateIngredient(17, bowlPos, true, 1);
                        AddToCombo("Cilantro Lime", 10);
                        break;

                    case "Egg":
                        InstantiateIngredient(18, bowlPos, true, 1);
                        AddToCombo("Hard Boiled Egg", 10);
                        break;
                    
                    case "Cheddar":
                        InstantiateIngredient(19, bowlPos, true, 1);
                        AddToCombo("Cheddar", 10);
                        break;

                    case "Pickled_o":
                        InstantiateIngredient(20, bowlPos, true, 1);
                        AddToCombo("Lime-Pickled Onions", 10);
                        break;

                    case "Jalapeno":
                        InstantiateIngredient(21, bowlPos, true, 1);
                        AddToCombo("Pickled Jalapenos", 10);
                        break;

                    case "Red_Cab":
                        InstantiateIngredient(22, bowlPos, true, 1);
                        AddToCombo("Red Cabbage", 10);
                        break;

                    case "Goat":
                        InstantiateIngredient(23, bowlPos, true, 1);
                        AddToCombo("Goat Cheese", 10);
                        break;

                    case "Pine":
                        InstantiateIngredient(24, bowlPos, true, 1);
                        AddToCombo("Pineapple", 10);
                        break;
                    
                    case "Carrots":
                        InstantiateIngredient(25, bowlPos, true, 1);
                        AddToCombo("Carrots", 10);
                        break;

                    case "Tofu":
                        InstantiateIngredient(26, bowlPos, true, 1);
                        AddToCombo("Tofu", 10);
                        break;

                    case "Chicken":
                        InstantiateIngredient(27, bowlPos, true, 1);
                        AddToCombo("Chicken", 10);
                        break;

                    case "Kale":
                        InstantiateIngredient(28, bowlPos, true, 1);
                        AddToCombo("Chicken", 10);
                        break;

                    case "Springmix":
                        InstantiateIngredient(29, bowlPos, true, 1);
                        AddToCombo("Spring Mix", 10);
                        break;

                    case "Spinach":
                        InstantiateIngredient(30, bowlPos, true, 1);
                        AddToCombo("Spinach", 10);
                        break;

                    // TODO add names and indices for bottles
                    case "B1":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, bowlPos, true, 1);
                        AddToCombo("B1", 10);
                        break;

                    case "B2":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, bowlPos, true, 1);
                        AddToCombo("B2", 10);
                        break;

                    case "B3":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, bowlPos, true, 1);
                        AddToCombo("B3", 10);
                        break;

                    case "B4":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, bowlPos, true, 1);
                        AddToCombo("B4", 10);
                        break;

                    case "B5":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, bowlPos, true, 1);
                        AddToCombo("B5", 10);
                        break;

                    case "B6":
                        AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, bowlPos, true, 1);
                        AddToCombo("B6", 10);
                        break;
                    
                    case "MainBowl":
                        MixBowl();
                        break;
                }

            }
        }
    }

    private void InstantiateIngredient(int index, Vector3 position, bool randomize, int count)
    {
        // Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
        if (randomize)
        {
            for (int i = 0; i < count; i++)
            {
                //Used to offset ingredients to instantiate into bowl
                Vector3 randomOffset = new Vector3(Random.Range(-0.09f, 0.1f), Random.Range(-0.2f, 0.2f), Random.Range(-0.175f, 0.05f));
                Instantiate(inge[index], position + offset + randomOffset, Quaternion.Euler(0, 0, 0), ingredientParent);
            }
        }
        else
        {
            // Instantiate(inge[0], position + offset, Quaternion.Euler(0, 0, 0), ingredientParent);
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

    // TODO Mix button doesn't work because "railPoint" is null
    private void MixBowl() // TODO should move to BowlAnime probably
    {
        if (!Manager.Instance.Mixing)
        {
            //railPoint = manager.GetComponent<LerpRail>().points[manager.GetComponent<LerpRail>().currPoint].GetChild(1);

            //Instantiate(pointtype[1], railPoint.position, railPoint.rotation, UI.transform);
            manager.GetComponent<DishManager>().mixBowl(false);
            manager.GetComponent<LerpRail>().advanceStopPoint();
            Manager.Instance.Score += 100;
        }
        Manager.Instance.Mixing = true;
        Mix.Play();
    }


//if (!Manager.Instance.IsLaunched)
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

}