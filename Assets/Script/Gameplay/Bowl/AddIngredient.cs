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
                if (ingredient != null)
                {
                    CreateAndCheckIngredient(ingredient);
                }
                if (ingredient == null) return; 
            }
        }
    }

    private void CreateAndCheckIngredient(Ingredient ingredient)
    {
        // Spawn prefab or pour liquid
        if (ingredient.IsLiquid())
        {
            PourLiquid(ingredient.GetColor());
        }
        else
        {
            InstantiateIngredient(ingredient.GetPrefab(), ingredient.GetCount());
        }

        AddToCombo(ingredient.GetName());
        SpawnIngredientText(ingredient.GetName(), ingredient.transform.position + ingredient.GetOffset());
    }

    private void InstantiateIngredient(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnIngredientInstance(prefab);
        }

        // After every addition, check if there's too many items in bowl
        if (transform.childCount > INGREDIENT_LIMIT)
        {
            DespawnExcessiveIngredients();
        }
    }

    private void SpawnIngredientInstance(GameObject prefab)
    {
        Vector3 randomOffset = new Vector3(UnityEngine.Random.Range(-0.09f, 0.1f), UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(-0.175f, 0.05f));
        Vector3 spawnPosition = transform.position + offset + randomOffset;
        Quaternion randomRotation = Quaternion.Euler(UnityEngine.Random.Range(-15, 15), UnityEngine.Random.Range(-15, 15), UnityEngine.Random.Range(-15, 15));

        GameObject ing = Instantiate(prefab, spawnPosition, randomRotation, this.transform);
        ing.transform.localScale = Vector3.Scale(ing.transform.localScale, new Vector3(.45f, .45f, .45f));
    }

    private void DespawnExcessiveIngredients()
    {
        int deleteCount = INGREDIENT_LIMIT / 4;
        for (int i = 0; i < deleteCount; i++)
        {
            int dice = UnityEngine.Random.Range(0, transform.childCount); // dice? more like russian roulette
            if (transform.GetChild(dice).CompareTag("Ingredients"))
            {
                Destroy(transform.GetChild(dice).gameObject);
            }
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

    private void AddToCombo(string ingredient)
    {
        //Separate check for dressing to add the correct one
        if (ingredient.Equals("Dressing"))
        {
            ingredient = GetCorrectDressingName(ingredient);
        }
        Manager.Instance.combo.Add(ingredient);
        listIngredients.GetComponent<ListIngredients>().UpdateIngredientsAdded(ingredient);
        
        prompts.GetComponent<TutorialPrompts>().addedIngredient(ingredient);
        if (DishManager.RequiresExtra(ingredient))
        {
            StartCoroutine(manager.GetComponent<DishManager>().SetExtraBar(ingredient));
        }

        Add.Play();
    }

    private string GetCorrectDressingName(string ingredient)
    {
        string[] dressings = Recipes.GetRecipe(DishManager.GetCurrentDish()).dressing;
        foreach (string dressing in dressings)
        {
            if (!Manager.Instance.combo.Contains(dressing))
            {
                return dressing;
            }
        }
        return ingredient;
    }

    private void SpawnIngredientText(string ingredient, Vector3 position)
    {
        if (DishManager.CheckIngredient(ingredient))
        {
            InstantiateText(greenText, ingredient, position);
        }
        else
        {
            InstantiateText(redText, ingredient, position);
        }
    }

    // Mix button doesn't work because "railPoint" is null
    private void MixBowl() // TODO should move to BowlAnimator probably
    {
        // Only mix at the cutting board
        if (manager.GetComponent<LerpRail>().currPoint != 6)
        {
            return;
        }

        if (!Manager.Instance.Mixing)
        {
            railPoint = manager.GetComponent<LerpRail>().points[manager.GetComponent<LerpRail>().currPoint].GetChild(1);

            InstantiateText(orangeText, "Mixed!", transform.position);
            DishManager.MixBowl();
            manager.GetComponent<LerpRail>().advanceStopPoint();
            // Manager.Instance.Score += 100;
        }
        DetachIngredient();
        Manager.Instance.Mixing = true;
        Mix.Play();
    }

    private void InstantiateText(GameObject textPrefab, string message, Vector3 textPosition)
    {
        float camFacingAngle = GameObject.Find("Main Camera").transform.rotation.eulerAngles.y;
        Quaternion textRotation = Quaternion.Euler(0, camFacingAngle, 0);
        GameObject textObject = Instantiate(textPrefab, textPosition, textRotation);

        textObject.GetComponent<TextMeshPro>().text = message;
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

    // Hint stuff should be in a different class
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

}