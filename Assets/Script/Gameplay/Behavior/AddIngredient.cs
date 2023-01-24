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
    public GameObject redText, greenText, orangeText;

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
                
                string ingredient = hitInfo.transform.name;
                switch(ingredient)
                {
                    // Define all the raycastable ingredient
                    // TODO use dictionary/set to look up ingredient names?
                    // TODO rename ingredient prefabs/wells
                    case "Brown":
                        InstantiateIngredient(0, 50);
                        AddToCombo("Brown Rice");
                        break;

                    case "Roots":
                        InstantiateIngredient(1, 50);
                        AddToCombo("Roots Rice");
                        break;

                    case "Chickp":
                        InstantiateIngredient(2, 20);
                        AddToCombo("Chickpeas");
                        break;

                    case "Broccoli":
                        InstantiateIngredient(3, 20);
                        AddToCombo("Broccoli");
                        break;

                    case "Cannellinib":
                        InstantiateIngredient(4, 20);
                        AddToCombo("Cannellini Beans");
                        break;

                    case "Beets":
                        InstantiateIngredient(5, 20);
                        AddToCombo("Roasted Beets");
                        break;
                    
                    case "Sweetp":
                        InstantiateIngredient(6, 20);
                        AddToCombo("Sweet Potatoes");
                        break;

                    case "Blackb":
                        InstantiateIngredient(7, 20);
                        AddToCombo("Black Beans");                        
                        break;

                    case "Bulgar":
                        InstantiateIngredient(8, 20);
                        AddToCombo("Bulgur");
                        break;

                    case "Corn":
                        InstantiateIngredient(9, 20);
                        AddToCombo("Charred Corn");
                        break;

                    case "Cucumber":
                        InstantiateIngredient(10, 20);
                        AddToCombo("Cucumber");
                        break;

                    case "Onion":
                        InstantiateIngredient(11, 20);
                        AddToCombo("Red Onions");
                        break;

                    case "Tomatoes":
                        InstantiateIngredient(12, 20);
                        AddToCombo("Grape Tomatoes");
                        break;
                    
                    case "Feta":
                        InstantiateIngredient(13, 20);
                        AddToCombo("Feta");
                        break;
                    
                    case "Parmesan":
                        InstantiateIngredient(14, 20);
                        AddToCombo("Shaved Parmesan");
                        break;

                    case "Avocado":
                        InstantiateIngredient(15, 1);
                        AddToCombo("Avocado");
                        break;

                    case "Chips":
                        InstantiateIngredient(16, 20);
                        AddToCombo("Pita Chips");
                        break;

                    case "Lime":
                        InstantiateIngredient(17, 20);
                        AddToCombo("Cilantro Lime");
                        break;

                    case "Egg":
                        InstantiateIngredient(18, 1);
                        AddToCombo("Hard Boiled Egg");
                        break;
                    
                    case "Cheddar":
                        InstantiateIngredient(19, 20);
                        AddToCombo("Cheddar");
                        break;

                    case "Pickled_o":
                        InstantiateIngredient(20, 20);
                        AddToCombo("Lime-Pickled Onions");
                        break;

                    case "Jalapeno":
                        InstantiateIngredient(21, 20);
                        AddToCombo("Pickled Jalapenos");
                        break;

                    case "Red_Cab":
                        InstantiateIngredient(22, 20);
                        AddToCombo("Red Cabbage");
                        break;

                    case "Goat":
                        InstantiateIngredient(23, 20);
                        AddToCombo("Goat Cheese");
                        break;

                    case "Pine":
                        InstantiateIngredient(24, 20);
                        AddToCombo("Pineapple");
                        break;
                    
                    case "Carrots":
                        InstantiateIngredient(25, 20);
                        AddToCombo("Carrots");
                        break;

                    case "Tofu":
                        InstantiateIngredient(26, 20);
                        AddToCombo("Tofu");
                        break;

                    case "Tofu_BBQ":
                        InstantiateIngredient(27, 20);
                        AddToCombo("BBQ Tofu");
                        break;

                    case "Chicken":
                        InstantiateIngredient(28, 20);
                        AddToCombo("Chicken");
                        break;

                    case "Kale":
                        InstantiateIngredient(29, 20);
                        AddToCombo("Kale", new Vector3(0.75f, 0f, -2.5f));
                        break;

                    case "Springmix":
                        InstantiateIngredient(30, 20);
                        AddToCombo("Spring Mix", new Vector3(0.15f, 0f, -2.5f));
                        break;

                    case "Spinach":
                        InstantiateIngredient(31, 20);
                        AddToCombo("Spinach", new Vector3(-0.6f, 0f, -2.5f));
                        break;

                    // TODO add names and indices for bottles
                    case "B1":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B1");
                        PourLiquid(new Color(1, 0, 0));
                        break;

                    case "B2":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B2");
                        PourLiquid(new Color(0, 1, 0));
                        break;

                    case "B3":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B3");
                        PourLiquid(new Color(0, 0, 1));
                        break;

                    case "B4":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B4");
                        PourLiquid(new Color(1, 1, 1));
                        break;

                    case "B5":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        //InstantiateIngredient(0, 1);
                        AddToCombo("B5");
                        PourLiquid(new Color(.75f, .5f, 0));
                        break;

                    case "B6":
                        //AnimateBottle(hitInfo.transform.gameObject);
                        // InstantiateIngredient(0, 1);
                        AddToCombo("B6");
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
            //Used to offset ingredient to instantiate into bowl
            Vector3 randomOffset = new Vector3(Random.Range(-0.09f, 0.1f), Random.Range(-0.2f, 0.2f), Random.Range(-0.175f, 0.05f));
            GameObject ing = Instantiate(inge[index], transform.position + offset + randomOffset, Quaternion.Euler(0, 0, 0), transform);
            ing.transform.localScale = Vector3.Scale(ing.transform.localScale, new Vector3(.45f, .45f, .45f));
        }
    }

    private void InstantiateText(GameObject textType, string message, Vector3 offset)
    {
        GameObject textObject = Instantiate(textType, transform.position + offset, railPoint.transform.rotation, UI.transform);
        textObject.GetComponent<TextMeshProUGUI>().text = message;
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

    // Add an ingredient to the user's bowl
    private void AddToCombo(string ingredient)
    {
        AddToCombo(ingredient, new Vector3(0f, 0f, 0f));
    }

    private void AddToCombo(string ingredient, Vector3 offset)
    {
        Manager.Instance.combo.Add(ingredient);
        if (manager.GetComponent<DishManager>().checkIng(ingredient))
        {
            InstantiateText(greenText, ingredient, offset);
        }
        else
        {
            InstantiateText(redText, ingredient, offset);
        }

        Add.Play();
        
        if (manager.GetComponent<DishManager>().requiresExtra(ingredient))
        {
            StartCoroutine(manager.GetComponent<DishManager>().setExtraBar(ingredient));
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

            InstantiateText(orangeText, "Mixed!", new Vector3(0f, 0f, 0f));
            manager.GetComponent<DishManager>().mixBowl(false);
            manager.GetComponent<LerpRail>().advanceStopPoint();
            // Manager.Instance.Score += 100;
        }
        detachIng();
        Manager.Instance.Mixing = true;
        Mix.Play();
    }

    public void attachIngToBowl()
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in ingredientParent)
        {
            if (child.CompareTag("Ingredients"))
            {
                children.Add(child);
            }
        }

        foreach (Transform child in children)
        {
            child.SetParent(transform);
        }
    }

    public void detachIng()
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Ingredients"))
            {
                children.Add(child);
            }
        }

        foreach (Transform child in children)
        {
            child.SetParent(ingredientParent);
        }
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