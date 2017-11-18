using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FruitMarketView : MonoBehaviour, IPlayerMoneyChangedListener {

    [SerializeField]
    private FruitData fruit;

    [SerializeField]
    private UIText text;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClicked);

        Contexts.sharedInstance.uI.CreateEntity().AddPlayerMoneyChanged(this);
    }

    private void Start()
    {
        text.content = fruit.SeedBuyPrice.ToString();
        text.Apply();
    }

    private void HandleButtonClicked()
    {
        Contexts.sharedInstance.input.CreateEntity().AddBuyFruit(fruit);
    }

    public void PlayerMoneyChanged(long value)
    {
        button.interactable = value > fruit.SeedBuyPrice;
    }
}
