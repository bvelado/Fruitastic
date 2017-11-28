using UnityEngine;
using TMPro;

public class InfoFieldView : MonoBehaviour {

    [SerializeField]
    private UIText labelText;

    [SerializeField]
    private UIText contentText;

    public void Display(string content)
    {
        contentText.content = content;
        contentText.Apply();
    }
}
