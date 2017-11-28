using UnityEngine;

public class GrowingInfoPanelView : MonoBehaviour, ISelectedEntityChangedListener {

    [SerializeField]
    private UIText nameText;
    [SerializeField]
    private UIText descriptionText;
    [SerializeField]
    private UIText producingText;
    [SerializeField]
    private UIText growingText;

    UIEntity e;

    private void OnEnable()
    {
        e = Contexts.sharedInstance.uI.CreateEntity();
        e.AddSelectedEntityChanged(this);
    }

    private void OnDisable()
    {
        if (e.isEnabled && e.hasSelectedEntityChanged)
            e.Destroy();
    }

    public void Display(GameEntity entity)
    {
        if(entity!=null && entity.isFruit)
        {
            if(entity.hasGrowing)
            {
                producingText.content = string.Format("{0}%", (1f * entity.growing.Elapsed) / (1f * entity.growable.Duration));
            }

            if (entity.hasProducing)
            {
                producingText.content = string.Format("{0}%", (1f * entity.producing.Elapsed) / (1f * entity.productor.Frequency));
            }
        }
    }

    public void SelectedEntityChanged(GameEntity entity)
    {
        if(entity != null && entity.hasTitle && entity.hasDescription)
        {
            nameText.content = entity.title.Content;
            descriptionText.content = entity.description.Content;

            nameText.Apply();
            descriptionText.Apply();
        }
    }
}
