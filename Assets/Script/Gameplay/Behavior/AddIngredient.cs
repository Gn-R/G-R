using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public GameObject flowEmitter;
    public GameObject pourEmitter;
    private Coroutine pourCoroutine;

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
                        InstantiateIngredient(0, 50);
                        AddToCombo("Brown Rice", 75);
                        break;

                    case "Roots":
                        InstantiateIngredient(1, 50);
                        AddToCombo("Roots Rice", 75);
                        break;

                    case "Chickp":
                        InstantiateIngredient(2, 20);
                        AddToCombo("Chickpeas", 100);
                        break;

                    case "Broccoli":
                        InstantiateIngredient(3, 20);
                        AddToCombo("Broccoli", 100);
                        break;

                    case "Cannellinib":
                        InstantiateIngredient(4, 20);
                        AddToCombo("Cannellini Beans", 100);
                        break;

                    case "Beets":
                        InstantiateIngredient(5, 20);
                        AddToCombo("Roasted Beets", 100);
                        break;
                    
                    case "Sweetp":
                        InstantiateIngredient(6, 20);
                        AddToCombo("Sweet Potatoes", 100);
                        break;

                    case "Blackb":
                        InstantiateIngredient(7, 20);
                        AddToCombo("Black Beans", 100);                        
                        break;

                    case "Bulgar":
                        InstantiateIngredient(8, 20);
                        AddToCombo("Bulgur", 100);
                        break;

                    case "Corn":
                        InstantiateIngredient(9, 20);
                        AddToCombo("Charred Corn", 100);
                        break;

                    case "Cucumber":
                        InstantiateIngredient(10, 20);
                        AddToCombo("Cucumber", 100);
                        break;

                    case "Onion":
                        InstantiateIngredient(11, 20);
                        AddToCombo("Red Onions", 100);
                        break;

                    case "Tomatoes":
                        InstantiateIngredient(12, 20);
                        AddToCombo("Grape Tomatoes", 100);
                        break;
                    
                    case "Feta":
                        InstantiateIngredient(13, 20);
                        AddToCombo("Feta", 100);
                        break;
                    
                    case "Parmesan":
                        InstantiateIngredient(14, 20);
                        AddToCombo("Shaved Parmesan", 100);
                        break;

                    case "Avocado":
                        InstantiateIngredient(15, 1);
                        AddToCombo("Avocado", 100);
                        break;

                    case "Chips":
                        InstantiateIngredient(16, 20);
                        AddToCombo("Pita Chips", 100);
                        break;

                    case "Lime":
                        InstantiateIngredient(17, 20);
                        AddToCombo("Cilantro Lime", 100);
                        break;

                    case "Egg":
                        InstantiateIngredient(18, 1);
                        AddToCombo("Hard Boiled Egg", 100);
                        break;
                    
                    case "Cheddar":
                        InstantiateIngredient(19, 20);
                        AddToCombo("Cheddar", 100);
                        break;

                    case "Pickled_o":
                        InstantiateIngredient(20, 20);
                        AddToCombo("Lime-Pickled Onions", 100);
                        break;

                    case "Jalapeno":
                        InstantiateIngredient(21, 20);
                        AddToCombo("Pickled Jalapenos", 100);
                        break;

                    case "Red_Cab":
                        InstantiateIngredient(22, 20);
                        AddToCombo("Red Cabbage", 100);
                        break;

                    case "Goat":
                        InstantiateIngredient(23, 20);
                        AddToCombo("Goat Cheese", 100);
                        break;

                    case "Pine":
                        InstantiateIngredient(24, 20);
                        AddToCombo("Pineapple", 100);
                        break;
                    
                    case "Carrots":
                        InstantiateIngredient(25, 20);
                        AddToCombo("Carrots", 100);
                        break;

                    case "Tofu":
                        InstantiateIngredient(26, 20);
                        AddToCombo("Tofu", 100);
                        break;

                    case "Tofu_BBQ":
                        InstantiateIngredient(27, 20);
                        AddToCombo("BBQTofu", 100);
                        break;

                    case "Chicken":
                        InstantiateIngredient(28, 20);
                        AddToCombo("Chicken", 200);
                        break;

                    case "Kale":
                        InstantiateIngredient(29, 20);
                        AddToCombo("Kale", 75);
                        if (manager.GetComponent<DishManager>().checkIng("Kale"))
                        {
                            GameObject point = Instantiate(pointtype[0], transform.position + new Vector3(0.75f, 0f, -2.5f), railPoint.transform.rotation * Quaternion.Euler(0, 180, 0), UI.transform);
                            point.GetComponent<TextMeshProUGUI>().text = "+75";
                        }
                        else
                        {
                            GameObject point = Instantiate(pointtype[2], transform.position + new Vector3(0.75f, 0f, -2.5f), railPoint.transform.rotation * Quaternion.Euler(0, 180, 0), UI.transform);
                            point.GetComponent<TextMeshProUGUI>().text = "-50";
                        }
                        break;

                    case "Springmix":
                        InstantiateIngredient(30, 20);
                        AddToCombo("Spring Mix", 75);
                        if (manager.GetComponent<DishManager>().checkIng("Springmix"))
                        {
                            GameObject point = Instantiate(pointtype[0], transform.position + new Vector3(0.15f, 0f, -2.5f), railPoint.transform.rotation * Quaternion.Euler(0, 180, 0), UI.transform);
                            point.GetComponent<TextMeshProUGUI>().text = "+75";
                        }
                        else
                        {
                            GameObject point = Instantiate(pointtype[2], transform.position + new Vector3(0.15f, 0f, -2.5f), railPoint.transform.rotation * Quaternion.Euler(0, 180, 0), UI.transform);
                            point.GetComponent<TextMeshProUGUI>().text = "-50";
                        }
                        break;

                    case "Spinach":
                        InstantiateIngredient(31, 20);
                        AddToCombo("Spinach", 75);
                        if (manager.GetComponent<DishManager>().checkIng("Spinach"))
                        {
                            GameObject point = Instantiate(pointtype[0], transform.position + new Vector3(-0.6f, 0f, -2.5f), railPoint.transform.rotation * Quaternion.Euler(0, 180, 0), UI.transform);
                            point.GetComponent<TextMeshProUGUI>().text = "+75";
                        }
                        else
                        {
                            GameObject point = Instantiate(pointtype[2], transform.position + new Vector3(-0.6f, 0f, -2.5f), railPoint.transform.rotation * Quaternion.Euler(0, 180, 0), UI.transform);
                            point.GetComponent<TextMeshProUGUI>().text = "-50";
                        }
                        break;

                    // TODO add names and indices for bottles
                    case "B1":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B1", 125);
                        PourLiquid(new Color(1, 0, 0));
                        break;

                    case "B2":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B2", 125);
                        PourLiquid(new Color(0, 1, 0));
                        break;

                    case "B3":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B3", 125);
                        PourLiquid(new Color(0, 0, 1));
                        break;

                    case "B4":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B4", 125);
                        PourLiquid(new Color(1, 1, 1));
                        break;

                    case "B5":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        //InstantiateIngredient(0, 1);
                        AddToCombo("B5", 125);
                        PourLiquid(new Color(.75f, .5f, 0));
                        break;

                    case "B6":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B6", 125);
                        PourLiquid(new Color(.5f, .3f, 0));
                        break;
                }

            }
        }
    }

    private void InstantiateIngredient(int index, int count)
    {
        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
        for (int i = 0; i < count; i++)
        {
            //Used to offset ingredients to instantiate into bowl
            Vector3 randomOffset = new Vector3(Random.Range(-0.09f, 0.1f), Random.Range(-0.2f, 0.2f), Random.Range(-0.175f, 0.05f));
            Instantiate(inge[index], transform.position + offset + randomOffset, Quaternion.Euler(0, 0, 0), ingredientParent);
        }
    }

    private void PourLiquid(Color color)
    {
        if (pourCoroutine != null)
        {
            StopCoroutine(pourCoroutine);
        }
        pourCoroutine = StartCoroutine(PourCoroutine(color));
    }

    private IEnumerator PourCoroutine(Color color)
    {
        pourEmitter.GetComponent<FLOW.FlowEmitter>().Fluid.Color = color;
        flowEmitter.GetComponent<FLOW.FlowEmitter>().Fluid.Color = color;
        flowEmitter.GetComponent<FLOW.FlowEmitter>().enabled = true;
        pourEmitter.GetComponent<FLOW.FlowEmitter>().enabled = true;

        yield return new WaitForSeconds(2f);
        flowEmitter.GetComponent<FLOW.FlowEmitter>().enabled = false;
        pourEmitter.GetComponent<FLOW.FlowEmitter>().enabled = false;

        pourCoroutine = null;
    }


    private void AddToCombo(string name, int points)
    {
        Manager.Instance.combo.Add(name);
        if (manager.GetComponent<DishManager>().checkIng(name))
        {
            Manager.Instance.Score += points;
        }
        else
        {
            Manager.Instance.Score -= 50;
            points = -50;
        }

        if (points > 0)
        {
            GameObject point = Instantiate(pointtype[0], transform.position, railPoint.transform.rotation, UI.transform);
            point.GetComponent<TextMeshProUGUI>().text = "+" + points;
        }
        else
        {
            GameObject point = Instantiate(pointtype[2], transform.position, railPoint.transform.rotation, UI.transform);
            point.GetComponent<TextMeshProUGUI>().text = "" + points;
        }


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
            railPoint = manager.GetComponent<LerpRail>().points[manager.GetComponent<LerpRail>().currPoint].GetChild(1);

            Instantiate(pointtype[1], railPoint.position, railPoint.rotation, UI.transform);
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