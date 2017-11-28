using System;
using Entitas;
using UnityEngine;

public class MarketStockView : MonoBehaviour, IStoredEntitiesNumberChangedListener {
    
    private IGroup<GameEntity> _storedEntities;

    public Transform Container;
    public StockItemView Prefab;

    private UIEntity e;

    private void OnEnable()
    {
        _storedEntities = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Stored).AnyOf(GameMatcher.Fruit, GameMatcher.Vegetable));

        e = Contexts.sharedInstance.uI.CreateEntity();
        e.AddStoredEntitiesNumberChanged(this);

        RegenerateViews();
    }

    private void OnDisable()
    {
        if (e.isEnabled && e.hasStoredEntitiesNumberChanged)
            e.Destroy();

        ClearAllViews();
    }

    private void RegenerateViews()
    {
        ClearAllViews();

        foreach (var storedEntity in _storedEntities.GetEntities())
        {
            var stockItem = Instantiate(Prefab, Container);

            if (storedEntity.hasIcon)
                stockItem.Icon.sprite = storedEntity.icon.Sprite;

            stockItem.Button.onClick.AddListener(() =>
            {
                GameEntity entity = storedEntity;

                //Debug.Log(entity);
                if(Contexts.sharedInstance.game.isSelected)
                    Contexts.sharedInstance.game.selectedEntity.isSelected = false;
                entity.isSelected = true;
            });
        }
    }

    private void ClearAllViews()
    {
        for (int i = 0; i < Container.childCount; i++)
            Destroy(Container.GetChild(i).gameObject);
    }

    public void StoredEntitiesNumberChanged(int value)
    {
        RegenerateViews();
    }
}
