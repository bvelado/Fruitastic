using System;
using UnityEngine;

public class MarketInfoPanelView : MonoBehaviour, ISelectedEntityChangedListener {

    [SerializeField]
    private UIText nameText;
    [SerializeField]
    private UIText descriptionText;
    [SerializeField]
    private UIText priceText;

    UIEntity e;

    private void OnEnable()
    {
        e = Contexts.sharedInstance.uI.CreateEntity();
        e.AddSelectedEntityChanged(this);
    }

    private void OnDisable()
    {
        if (e.isEnabled && e.hasSelectedEntityChanged)
            e.Destroy();
    }

    private void Display(FruitData fruit)
    {
        nameText.content = fruit.Name;
        descriptionText.content = fruit.Description;
        priceText.content = fruit.SeedBuyPrice.ToString();

        nameText.Apply();
        descriptionText.Apply();
        priceText.Apply();
    }

    private void Display(VegetableData vegetable)
    {
        nameText.content = vegetable.Name;
        descriptionText.content = vegetable.Description;
        priceText.content = vegetable.SeedBuyPrice.ToString();

        nameText.Apply();
        descriptionText.Apply();
        priceText.Apply();
    }

    public void SelectedEntityChanged(GameEntity entity)
    {
        if(entity != null)
        {
            if (entity.hasFruit)
                Display(entity.fruit.FruitData);

            if (entity.hasVegetable)
                Display(entity.vegetable.VegetableData);
        }
    }
}
