﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VegetableMarketView : MonoBehaviour
{

    [SerializeField]
    private VegetableData vegetable;
    [SerializeField]
    private InfoPanelView infoPanelView;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClicked);
    }

    private void HandleButtonClicked()
    {
        var e = Contexts.sharedInstance.game.CreateEntity();
        e.AddBuyable(vegetable.SeedBuyPrice);
        e.AddVegetable(vegetable);
        if (Contexts.sharedInstance.game.isSelected)
            Contexts.sharedInstance.game.selectedEntity.isSelected = false;
        e.isSelected = true;
    }
}