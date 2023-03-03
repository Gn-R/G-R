using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapBowlDebug : MonoBehaviour
{
    private Button btn;
    public int bowl = 1;
    public Image label;
    public Sprite sprite1;
    public Sprite sprite2;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeBowl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeBowl()
    {
        DishManager.SetRecipe("G & R Bowl " + bowl);
        GameObject.Find("Hud").GetComponent<ListIngredients>().UpdateRecipeIngredients();
        if (bowl == 1)
        {
            bowl = 2;
            label.sprite = sprite2;
        } 
        else
        {
            label.sprite = sprite1;
            bowl = 1;
        }
    }
}
