using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlantButton : MonoBehaviour, ISelectedEntityChangedListener
{
    UIEntity e;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        e = Contexts.sharedInstance.uI.CreateEntity();
        e.AddSelectedEntityChanged(this);

        button = GetComponent<Button>();
        button.onClick.AddListener(HandleButtonClicked);
    }

    private void OnDisable()
    {
        if (e.isEnabled && e.hasSelectedEntityChanged)
            e.Destroy();

        button.onClick.RemoveAllListeners();
    }

    public void SelectedEntityChanged(GameEntity entity)
    {
        if(entity == null)
        {
            button.interactable = false;
            return;
        }

        if(entity.isStored && (!entity.hasFruit || !entity.hasVegetable) && entity.isSeed) {
            button.interactable = true;
        } else
        {
            button.interactable = false;
        }
    }

    private void HandleButtonClicked()
    {
        if(Contexts.sharedInstance.game.isSelected)
            Contexts.sharedInstance.input.CreateEntity().AddPlantSelectedEntity(Contexts.sharedInstance.game.selectedEntity);
    }
}
