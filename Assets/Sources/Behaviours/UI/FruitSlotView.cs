using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FruitSlotView : MonoBehaviour, IFruitSlotChangedListener
{
    private static int Count;

    public int Index { get; private set; }

    [Header("Gameplay")]
    [SerializeField]
    private bool startsLocked;
    [SerializeField]
    private bool startsBuyable;
    [SerializeField]
    private long price;

    [Space]

    [Header("UI References")]
    private Button button;
    [SerializeField]
    private Image fruitImage;
    [SerializeField]
    private Image growthBar;
    [SerializeField]
    private Image productionBar;
    [SerializeField]
    private CanvasGroup available;
    [SerializeField]
    private UIText priceText;
    [SerializeField]
    private CanvasGroup unavailable;

    private bool isInitialized = false;
    private UIEntity uiEntity;

    private void Awake()
    {
        if (isInitialized)
            return;

        Index = Count;
        Count++;        
        
        var gameEntity = Contexts.sharedInstance.game.CreateEntity();
        gameEntity.AddFruitSlot(Index);
        gameEntity.isLocked = startsLocked;
        if (startsLocked && startsBuyable)
        {
            gameEntity.AddBuyable(price);
        }

        uiEntity = Contexts.sharedInstance.uI.CreateEntity();
        uiEntity.AddFruitSlotView(Index, this);
        uiEntity.AddFruitSlotChanged(this);

        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClicked);

        UpdateView(gameEntity);

        isInitialized = true;
    }

    private void HandleButtonClicked()
    {
        var fruitSlotEntity = Contexts.sharedInstance.game.GetFruitSlotEntityBySlotIndex(Index);
        if (fruitSlotEntity != null)
        {
            if (fruitSlotEntity.isLocked)
            {
                // Fruit slot is locked
                if(fruitSlotEntity.hasBuyable)
                {
                    // If this slot can be bought
                    Contexts.sharedInstance.input.CreateEntity().AddBuyFruitSlot(Index);
                }
            } else
            {
                // Fruit slot is not locked, display info about this slot.
            }
        }
    }

    /// <summary>
    /// Pass in a game entity with FruitSlot component
    /// </summary>
    /// <param name="fruitSlot"></param>
    private void UpdateView(GameEntity fruitSlot)
    {
        priceText.content = fruitSlot.hasBuyable ? fruitSlot.buyable.Price.ToString() : "0";
        priceText.Apply();

        available.alpha = (fruitSlot.isLocked && fruitSlot.hasBuyable) ? 1f : 0f;
        unavailable.alpha = (fruitSlot.isLocked && !fruitSlot.hasBuyable) ? 1f : 0f;

        var fruit = Contexts.sharedInstance.game.GetFruitEntityBySlotIndex(Index);
        if(fruit != null)
        {
            growthBar.fillAmount = fruit.hasGrowing ? fruit.growing.Elapsed / fruit.fruit.FruitData.GrowthDuration : 0f;
            productionBar.fillAmount = fruit.hasProducing ? fruit.producing.Elapsed / fruit.fruit.FruitData.Frequency : 0f;
        }
    }

    public void FruitSlotChanged(GameEntity e)
    {
        Debug.Log(e);
        UpdateView(e);
    }
}
