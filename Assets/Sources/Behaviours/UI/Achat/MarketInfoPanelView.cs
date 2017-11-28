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

    private void Display(GameEntity fruit)
    {
        nameText.content = fruit.title.Content;
        descriptionText.content = fruit.description.Content;
        priceText.content = fruit.buyable.Price.ToString();

        nameText.Apply();
        descriptionText.Apply();
        priceText.Apply();
    }

    public void SelectedEntityChanged(GameEntity entity)
    {
        if(entity != null && (entity.isFruit || entity.isVegetable))
        {
            Display(entity);
        }
    }
}
