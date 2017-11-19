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
        e.AddBuyable(fruit.SeedBuyPrice);
        e.AddFruit(fruit);
        if (Contexts.sharedInstance.game.isSelected)
            Contexts.sharedInstance.game.selectedEntity.isSelected = false;
        e.isSelected = true;
    }
}
