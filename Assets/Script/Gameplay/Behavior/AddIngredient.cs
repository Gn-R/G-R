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
            Vector3 randomOffset = new Vector3(Random.Range(-0.09f, 0.1f), Random.Range(-0.2f, 0.2f), Random.Range(-0.175f, 0.05f));
            GameObject ing = Instantiate(prefab, transform.position + offset + randomOffset, Quaternion.Euler(0, 0, 0), transform);
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

    private void AddToCombo(string ingredient, Vector3 offset)
    {
        Manager.Instance.combo.Add(ingredient);
        if (manager.GetComponent<DishManager>().CheckIngredient(ingredient))
        {
            InstantiateText(greenText, ingredient, offset);
        }
        else
        {
            InstantiateText(redText, ingredient, offset);
        }

        Add.Play();
        
        if (manager.GetComponent<DishManager>().RequiresExtra(ingredient))
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
        if (!Manager.Instance.Mixing)
        {
            railPoint = manager.GetComponent<LerpRail>().points[manager.GetComponent<LerpRail>().currPoint].GetChild(1);

            InstantiateText(orangeText, "Mixed!", new Vector3(0f, 0f, 0f));
            DishManager.MixBowl();
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

}