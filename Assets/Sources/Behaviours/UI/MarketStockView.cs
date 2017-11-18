using System;
using Entitas;
using UnityEngine;

public class MarketStockView : MonoBehaviour {

    public InfoPanelView infoPanelView;

    private IGroup<GameEntity> _fruits;
    private IGroup<GameEntity> _vegetables;

    private bool isInitialized = false;

    public Transform Container;
    public StockItemView Prefab;

    private void Start()
    {
        _fruits = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Stored));
        _vegetables = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Vegetable, GameMatcher.Stored));

        _fruits.OnEntityAdded += RegenerateViews;
        _fruits.OnEntityRemoved += RegenerateViews;
        _vegetables.OnEntityAdded += RegenerateViews;
        _vegetables.OnEntityRemoved += RegenerateViews;

        isInitialized = true;
    }
    
    private void RegenerateViews(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    {
        for (int i = 0; i < Container.childCount; i++)
            DestroyImmediate(Container.GetChild(i).gameObject);

        foreach(var fruit in _fruits.GetEntities())
        {
            var stockItem = Instantiate(Prefab, Container);
            stockItem.Icon.sprite = fruit.fruit.FruitData.FruitIcon;
            stockItem.Button.onClick.AddListener(() => infoPanelView.Display(fruit.fruit.FruitData));
        }

        foreach (var vegetable in _vegetables.GetEntities())
        {
            var stockItem = Instantiate(Prefab, Container);
            stockItem.Icon.sprite = vegetable.vegetable.VegetableData.VegetableIcon;
            stockItem.Button.onClick.AddListener(() => infoPanelView.Display(vegetable.vegetable.VegetableData));
        }
    }
}
