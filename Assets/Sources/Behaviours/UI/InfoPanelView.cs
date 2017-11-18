using UnityEngine;

public class InfoPanelView : MonoBehaviour {

    [SerializeField]
    private UIText nameText;
    [SerializeField]
    private UIText descriptionText;
    [SerializeField]
    private UIText priceText;

    public void Display(FruitData fruit)
    {
        nameText.content = fruit.Name;
        descriptionText.content = fruit.Description;
        priceText.content = fruit.SeedBuyPrice.ToString();

        nameText.Apply();
        descriptionText.Apply();
        priceText.Apply();
    }

    public void Display(VegetableData vegetable)
    {
        nameText.content = vegetable.Name;
        descriptionText.content = vegetable.Description;
        priceText.content = vegetable.SeedBuyPrice.ToString();

        nameText.Apply();
        descriptionText.Apply();
        priceText.Apply();
    }

}
