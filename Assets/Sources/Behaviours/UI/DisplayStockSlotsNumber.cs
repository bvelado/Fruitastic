using UnityEngine;

public class DisplayStockSlotsNumber : MonoBehaviour, IStoredEntitiesNumberChangedListener {

    [SerializeField]
    private UIText text;

    private void Start()
    {
        Contexts.sharedInstance.uI.CreateEntity().AddStoredEntitiesNumberChanged(this);
    }

    public void StoredEntitiesNumberChanged(int value)
    {
        text.content = string.Format("{0}/{1}", value, GameParametersManager.Instance.Parameters.MAX_STOCK_SLOTS);
        text.Apply();
    }
}
