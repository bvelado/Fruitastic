using Entitas;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SellButton : MonoBehaviour {

    //private IGroup<GameEntity> _selected;

    //private BuyPageManager manager;

    //private bool initialized = false;
    //private GameEntity current;

    //private void Start()
    //{
    //    if (initialized)
    //        return;

    //    _selected = Contexts.sharedInstance.game.GetGroup(GameMatcher.Selected);

    //    manager = FindObjectOfType<BuyPageManager>();
    //    GetComponent<Button>().onClick.AddListener(HandleButtonClicked);

    //    _selected.OnEntityAdded += _selected_OnEntityAdded;  

    //    initialized = true;
    //}

    //private void _selected_OnEntityAdded(IGroup<GameEntity> group, GameEntity entity, int index, IComponent component)
    //{
    //    manager.ResetSelected();
    //    gameObject.SetActive(true);
    //    current = entity;
    //}

    //private void HandleButtonClicked()
    //{
    //    if (current == null)
    //        return;

    //    if (current.hasFruit)
    //        Contexts.sharedInstance.input.CreateEntity().AddSellFruit(current);

    //    if (current.hasVegetable)
    //        Contexts.sharedInstance.input.CreateEntity().AddSellVegetable(current);
    //}
}
