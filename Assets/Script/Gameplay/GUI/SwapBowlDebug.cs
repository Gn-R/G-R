using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapBowlDebug : MonoBehaviour
{
    private Button btn;
    public Image label;
    public Sprite sprite1;
    public Sprite sprite2;
    // Start is called before the first frame update
    void Start()
    {
        Manager.Instance.bowltest = 1;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeBowl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeBowl()
    {
        
        if (Manager.Instance.bowltest == 1)
        {
            label.sprite = sprite2;
            DishManager.SetRecipe("G & R Bowl " + Manager.Instance.bowltest);
            GameObject.Find("Hud").GetComponent<ListIngredients>().UpdateRecipeIngredients();
            Manager.Instance.bowltest = 2;
            
        } 
        else if (Manager.Instance.bowltest == 2)
        {
            label.sprite = sprite1;
            DishManager.SetRecipe("G & R Bowl " + Manager.Instance.bowltest);
            GameObject.Find("Hud").GetComponent<ListIngredients>().UpdateRecipeIngredients();
            Manager.Instance.bowltest = 1;
        }
    }
}
