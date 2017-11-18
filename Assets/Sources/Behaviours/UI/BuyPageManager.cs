using Entitas;
using UnityEngine;
using UnityEngine.UI;

public enum ESelectMode
{
    Buy,
    Sell
}

public class BuyPageManager : MonoBehaviour {

    [Header("Stock")]
    [SerializeField]
    private Transform stockItemsContainer;
    [SerializeField]
    private StockItemView stockItemViewPrefab;

    [Header("Info panel")]
    [SerializeField]
    private InfoPanelView infoPanelView;

    [Header("Buttons")]
    [SerializeField]
    private Button sellButton;
    [SerializeField]
    private Button buyButton;

    private IGroup<GameEntity> _fruits;
    private IGroup<GameEntity> _vegetables;

    private bool isInitialized = false;

    public GameEntity currentSelected;

    private void Start()
    {
        _fruits = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Fruit, GameMatcher.Stored));
        _vegetables = Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.Vegetable, GameMatcher.Stored));

        _fruits.OnEntityAdded += RegenerateStockViews;
        _fruits.OnEntityRemoved += RegenerateStockViews;
        _vegetables.OnEntityAdded += RegenerateStockViews;
        _vegetables.OnEntityRemoved += RegenerateStockViews;

        isInitialized = true;
    }

    private void RegenerateStockViews(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    {
        for (int i = 0; i < stockItemsContainer.childCount; i++)
            DestroyImmediate(stockItemsContainer.GetChild(i).gameObject);

        foreach (var fruit in _fruits.GetEntities())
        {
            var stockItem = Instantiate(stockItemViewPrefab, stockItemsContainer);
            stockItem.Icon.sprite = fruit.fruit.FruitData.FruitIcon;
            stockItem.Button.onClick.AddListener(() => infoPanelView.Display(fruit.fruit.FruitData));
        }

        foreach (var vegetable in _vegetables.GetEntities())
        {
            var stockItem = Instantiate(stockItemViewPrefab, stockItemsContainer);
            stockItem.Icon.sprite = vegetable.vegetable.VegetableData.VegetableIcon;
            stockItem.Button.onClick.AddListener(() => infoPanelView.Display(vegetable.vegetable.VegetableData));
        }
    }

    public void SetSelected(GameEntity gameEntity, ESelectMode selectMode)
    {
        currentSelected = gameEntity;

        buyButton.gameObject.SetActive(false);
        sellButton.gameObject.SetActive(false);

        buyButton.onClick.RemoveAllListeners();
        sellButton.onClick.RemoveAllListeners();

        if(gameEntity.hasFruit)
        {
            infoPanelView.Display(gameEntity.fruit.FruitData);

            if (selectMode == ESelectMode.Buy)
            {
                buyButton.gameObject.SetActive(true);
                buyButton.onClick.AddListener(() => Contexts.sharedInstance.input.CreateEntity().AddBuyFruit(gameEntity.fruit.FruitData));
            }
            else if (selectMode == ESelectMode.Sell)
            {
                sellButton.gameObject.SetActive(true);
                sellButton.onClick.AddListener(() => Contexts.sharedInstance.input.CreateEntity().AddSellFruit(gameEntity));
            }
        }

        if(gameEntity.hasVegetable)
        {
            infoPanelView.Display(gameEntity.vegetable.VegetableData);

            if (selectMode == ESelectMode.Buy)
            {
                buyButton.gameObject.SetActive(true);
                buyButton.onClick.AddListener(() => Contexts.sharedInstance.input.CreateEntity().AddBuyVegetable(gameEntity.vegetable.VegetableData));
            }
            else if (selectMode == ESelectMode.Sell)
            {
                sellButton.gameObject.SetActive(true);
                sellButton.onClick.AddListener(() => Contexts.sharedInstance.input.CreateEntity().AddSellVegetable(gameEntity));
            }
        }
    }

    public void ResetSelected()
    {
        currentSelected = null;
    }

    public GameEntity GetSelected()
    {
        return currentSelected;
    }

}
