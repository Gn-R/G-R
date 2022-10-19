using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// A button that displays a recipe hint text box for the user
public class ShowRecipe : MonoBehaviour
{
    [SerializeField] GameObject showRecipeButton;
    private Image showRecipeImage;
    [SerializeField] TextMeshProUGUI comboTextField; // what the player currently has
    [SerializeField] TextMeshProUGUI orderTextField; // what the player is supposed to make

    private bool showingRecipe;
    private List<string> recipe;

    public GameObject manager;

    void Start()
    {
        showingRecipe = false;
        showRecipeButton.GetComponent<Button>().onClick.AddListener(ToggleRecipeShown);
        showRecipeImage = showRecipeButton.GetComponent<Image>();
        orderTextField.gameObject.SetActive(false);
    }

    void Update()
    {
        List<string> playerCombo = Manager.Instance.combo;
        string comboText = "";
        foreach (string item in playerCombo)
        {
            comboText += item + ", ";
        }
        comboTextField.text = comboText;
    }

    public void SetRecipe(List<string> newRecipe)
    {
        recipe = newRecipe;
        string orderText = "";
        foreach (string str in recipe)
        {
            orderText += str + ", ";
        }
        orderTextField.text = orderText;
    }

    // BUG doesn't update combo/order after AddListener is used
    public void ToggleRecipeShown()
    {        
        showingRecipe = !showingRecipe;
        if (showingRecipe)
        {
            showRecipeImage.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            showRecipeImage.color = new Color(1, 1, 1);
        }

        comboTextField.gameObject.SetActive(!showingRecipe);
        orderTextField.gameObject.SetActive(showingRecipe);
    }
}
