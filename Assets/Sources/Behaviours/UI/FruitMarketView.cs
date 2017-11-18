using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FruitMarketView : MonoBehaviour, IPlayerMoneyChangedListener {

    [SerializeField]
    private FruitData fruit;

    [SerializeField]
    private UIText text;

    [SerializeField]
    private InfoPanelView infoPanelView;

    private BuyPageManager manager;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClicked);

        if (Contexts.sharedInstance.game.hasPlayerMoney)
        PlayerMoneyChanged(Contexts.sharedInstance.game.playerMoney.Money);

        Contexts.sharedInstance.uI.CreateEntity().AddPlayerMoneyChanged(this);
    }

    private void Start()
    {
        text.content = fruit.SeedBuyPrice.ToString();
        text.Apply();

        manager = FindObjectOfType<BuyPageManager>();
    }

    private void HandleButtonClicked()
    {
        //Contexts.sharedInstance.input.CreateEntity().AddBuyFruit(fruit);
        infoPanelView.Display(fruit);
        manager.SetSelected(null, ESelectMode.Buy);
    }

    public void PlayerMoneyChanged(long value)
    {

    }
}
