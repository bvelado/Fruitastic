using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VegetableMarketView : MonoBehaviour, IPlayerMoneyChangedListener
{

    [SerializeField]
    private VegetableData vegetable;

    [SerializeField]
    private UIText text;

    [SerializeField]
    private InfoPanelView infoPanelView;

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
        text.content = vegetable.SeedBuyPrice.ToString();
        text.Apply();
    }

    private void HandleButtonClicked()
    {
        //Contexts.sharedInstance.input.CreateEntity().AddBuyVegetable(vegetable);
        infoPanelView.Display(vegetable);
    }

    public void PlayerMoneyChanged(long value)
    {
        button.interactable = value > vegetable.SeedBuyPrice;
    }
}
