using UnityEngine;
using TMPro;
using System.Text;
using System.Collections.Generic;

[ExecuteInEditMode()]
[RequireComponent(typeof(TextMeshProUGUI))]
public class UIText : MonoBehaviour {

    [SerializeField]
    [TextArea]
    public string content;
    [SerializeField]
    private List<string> styles = new List<string>();
    [SerializeField]
    private TextMeshProUGUI text;

    private void Reset()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        Apply();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (!Application.isPlaying)
        {
            Apply();
        }
    }
#endif

    private string Format(string content)
    {
        StringBuilder sb = new StringBuilder();

        foreach(var style in styles)
        {
            sb.Append(string.Format("<style=\"{0}\">", style));
        }
        sb.Append(content);
        foreach(var style in styles)
        {
            sb.Append("</style>");
        }
        
        return sb.ToString();
    }

    public string GetStylizedText(string content)
    {
        return Format(content);
    }

    public void Apply()
    {
        if(content != null && text != null)
            text.text = Format(content);
    }
}
