using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FruitMarketView : MonoBehaviour {

    [SerializeField]
    private FruitData fruit;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClicked);
    }
    
    private void HandleButtonClicked()
    {
        var e = Contexts.sharedInstance.game.CreateEntity();
        e.isFruit = true;
        e.AddBuyable(fruit.SeedBuyPrice);
        e.AddTitle(fruit.Name);
        e.AddDescription(fruit.Description);
        e.isSeed = true;
        e.AddGrowable(fruit.GrowthDuration);
        e.AddProductor(fruit.Frequency);
        if (Contexts.sharedInstance.game.isSelected)
            Contexts.sharedInstance.game.selectedEntity.isSelected = false;
        e.isSelected = true;
    }
}
