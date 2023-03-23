using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// TODO move this script to MBP object and fix prefab position and size
public class AddIngredient : MonoBehaviour
{
    private static readonly int INGREDIENT_LIMIT = 400;

    [SerializeField] GameObject listIngredients;
    [SerializeField] GameObject textPrefab;

    public GameObject[] pointpos;
    public GameObject prompts;
    public Canvas UI;
    public Button mixButton;
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

    private Coroutine hintCoroutine;

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

                // Is object an ingredient?
                Ingredient ingredient = hitInfo.transform.GetComponent<Ingredient>();
                if (ingredient == null) return;                
                
                //  Spawn prefab or pour liquid
                if (ingredient.IsLiquid())
                {
                    PourLiquid(ingredient.GetColor());
                }
                else
                {
                    InstantiateIngredient(ingredient.GetPrefab(), ingredient.GetCount());
                }

                // Add to bowl
                AddToCombo(ingredient.GetName(), ingredient.GetOffset());
            }
        }
    }

    private void InstantiateIngredient(GameObject prefab, int count)
    {
        //Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation, YourParent.transform)
        for (int i = 0; i < count; i++)
        {
            //Used to offset ingredient to instantiate into bowl
            Vector3 randomOffset = new Vector3(UnityEngine.Random.Range(-0.09f, 0.1f), UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(-0.175f, 0.05f));
            GameObject ing = Instantiate(prefab, transform.position + offset + randomOffset, Quaternion.Euler(0, 0, 0), transform);
            ing.transform.localScale = Vector3.Scale(ing.transform.localScale, new Vector3(.45f, .45f, .45f));
        }

        //After every addition, check if there's too many items in bowl
        if (transform.childCount > INGREDIENT_LIMIT)
        {
            int delete_count = INGREDIENT_LIMIT / 4;
            for (int i = 0; i < delete_count; i++)
            {
                int dice = UnityEngine.Random.Range(0, transform.childCount);
                if (transform.GetChild(dice).CompareTag("Ingredients"))
                {
                    Destroy(transform.GetChild(dice).gameObject);
                }
            }
            // Debug.Log("destroy");
        }
    }

    private void InstantiateText(GameObject textType, string message, Vector3 offset)
    {
        GameObject parentPos = Array.Find(pointpos, element => element.name.Equals(message));
        GameObject textObject;
        if (parentPos == null)
        {
            textObject = Instantiate(textType, transform);
        } 
        else
        {
            textObject = Instantiate(textType, parentPos.transform);
        }

        if (GameObject.Find("Main Camera").transform.rotation.eulerAngles.y > 0)
        {
            textObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        //textObject.transform.position += offset;
        textObject.GetComponent<TextMeshPro>().text = message;
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

    public void ShowHint(float sec)
    {
        if (hintCoroutine != null)
        {
            StopCoroutine(hintCoroutine);
        }
        hintCoroutine = StartCoroutine(HintCoroutine(sec));
    }

    private IEnumerator HintCoroutine(float sec)
    {
        List<GameObject> hintTexts = new List<GameObject>();
        foreach (GameObject clone in pointpos)
        {
            GameObject hintText = Instantiate(textPrefab, clone.transform, false);
            hintText.transform.localPosition = new Vector3(.05f, .182f, -0.04f);
            if (GameObject.Find("Main Camera").transform.rotation.eulerAngles.y > 0)
            {
                hintText.transform.localPosition = new Vector3(.05f, .182f, 0.07f);
                hintText.transform.rotation = Quaternion.Euler(90, 0, 90);
            }
            else
            {
                hintText.transform.localPosition = new Vector3(.05f, .182f, -0.08f);
            }
            hintText.GetComponent<TextMeshPro>().text = clone.name;
            hintTexts.Add(hintText);
        }
        yield return new WaitForSeconds(sec);
        foreach (GameObject text in hintTexts)
        {
            Destroy(text);
        }
    }

    private void AddToCombo(string ingredient, Vector3 offset)
    {
        //Separate check for dressing to add the correct one
        if (ingredient.Equals("Dressing"))
        {
            string[] dressings = Recipes.GetRecipe(DishManager.GetCurrentDish()).dressing;
            foreach (string dressing in dressings)
            {
                if (!Manager.Instance.combo.Contains(dressing))
                {
                    ingredient = dressing;
                    break;
                }
            }

            if (ingredient.Equals("Dressing"))
            {
                return;
            }
        }
        
        Manager.Instance.combo.Add(ingredient);
        listIngredients.GetComponent<ListIngredients>().UpdateIngredientsAdded(ingredient);
        if (DishManager.CheckIngredient(ingredient))
        {
            InstantiateText(greenText, ingredient, offset);
        }
        else
        {
            InstantiateText(redText, ingredient, offset);
        }

        //if (points > 0)
        //{
        //    GameObject point = Instantiate(pointtype[0], transform.position, railPoint.transform.rotation, UI.transform);
        //    point.GetComponent<TextMeshProUGUI>().text = "+" + points;
        //}
        //else
        //{
        //    GameObject point = Instantiate(pointtype[2], transform.position, railPoint.transform.rotation, UI.transform);
        //    point.GetComponent<TextMeshProUGUI>().text = "" + points;
        //}

        Debug.Log(ingredient);
        prompts.GetComponent<TutorialPrompts>().addedIngredient(ingredient);
        

        Add.Play();
        
        if (DishManager.RequiresExtra(ingredient))
        {
            StartCoroutine(manager.GetComponent<DishManager>().SetExtraBar(ingredient));
        }
    }

    private void AnimateBottle(GameObject obj)
    {
        BottleAnimator anim = obj.GetComponent<BottleAnimator>();
        anim.OnBottleClick();
    }

    // TODO Mix button doesn't work because "railPoint" is null
    private void MixBowl() // TODO should move to BowlAnimator probably
    {
        //Only mix at the cutting board
        if (manager.GetComponent<LerpRail>().currPoint != 6)
        {
            return;
        }

        if (!Manager.Instance.Mixing)
        {
            railPoint = manager.GetComponent<LerpRail>().points[manager.GetComponent<LerpRail>().currPoint].GetChild(1);

            InstantiateText(orangeText, "Mixed!", new Vector3(0f, 0f, 0f));
            DishManager.MixBowl();
            manager.GetComponent<LerpRail>().advanceStopPoint();
            // Manager.Instance.Score += 100;
        }
        DetachIngredient();
        Manager.Instance.Mixing = true;
        Mix.Play();
    }

    public void AttachIngredientToBowl()
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

    public void DetachIngredient()
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

}