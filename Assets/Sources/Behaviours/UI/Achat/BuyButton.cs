using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuyButton : MonoBehaviour, ISelectedEntityChangedListener, IPlayerMoneyChangedListener
{
    private UIEntity e;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnEnable()
    {        
        e = Contexts.sharedInstance.uI.CreateEntity();
        e.AddSelectedEntityChanged(this);
        e.AddPlayerMoneyChanged(this);

        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClicked);
    }

    public void OnDisable()
    {
        if (e.isEnabled && e.hasSelectedEntityChanged && e.hasPlayerMoneyChanged)
            e.Destroy();

        button.onClick.RemoveAllListeners();
    }

    public void SelectedEntityChanged(GameEntity entity)
    {
        if (entity == null)
        {
            button.interactable = false;
            return;
        }
            

        if (!entity.hasBuyable)
        {
            button.interactable = false;
            return;
        }

        if(Contexts.sharedInstance.game.hasPlayerMoney)
        {
            button.interactable = entity.buyable.Price < Contexts.sharedInstance.game.playerMoney.Money;            
        }
    }

    private void HandleButtonClicked()
    {
        if(Contexts.sharedInstance.game.isSelected && Contexts.sharedInstance.game.selectedEntity.hasBuyable)
        {
            var inputEntity = Contexts.sharedInstance.input.CreateEntity();
            inputEntity.isBuySelected = true;
        }
    }

    public void PlayerMoneyChanged(long value)
    {
        if (!Contexts.sharedInstance.game.isSelected || !Contexts.sharedInstance.game.selectedEntity.hasBuyable)
        {
            button.interactable = false;
            return;
        }   

        if (Contexts.sharedInstance.game.hasPlayerMoney)
        {
            button.interactable = value > Contexts.sharedInstance.game.selectedEntity.buyable.Price;
        }
    }
}
