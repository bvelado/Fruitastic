using System;
using UnityEngine;

public class MarketInfoPanelView : MonoBehaviour, ISelectedEntityChangedListener
{

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

    private void Display(GameEntity entity)
    {
        if (entity.hasTitle)
        {
            nameText.content = entity.title.Content;
            nameText.Apply();
        }

        if (entity.hasDescription)
        {
            descriptionText.content = entity.description.Content;
            descriptionText.Apply();
        }

        if (entity.hasBuyable)
        {
            priceText.content = entity.buyable.Price.ToString();
            priceText.Apply();
        }

    }

    public void SelectedEntityChanged(GameEntity entity)
    {
        if (entity != null && (entity.isFruit || entity.isVegetable))
        {
            Display(entity);
        }
    }
}
