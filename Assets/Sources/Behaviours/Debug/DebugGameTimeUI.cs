using TMPro;
using UnityEngine;
using Entitas;

public class DebugGameTimeUI : MonoBehaviour, ITickChangedListener {

    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        Contexts.sharedInstance.uI.CreateEntity().AddTickChanged(this);
    }

    public void TickChanged(long value)
    {
        text.text = string.Format("{0}", value);
    }
}
