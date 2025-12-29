using UnityEngine;
using TMPro;

public class TextUIHover : MonoBehaviour
{
    public static TextUIHover Instance;

    public TMP_Text tooltipText;
    public GameObject tooltipRoot;

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show(string text)
    {
        tooltipText.text = text;
        tooltipRoot.SetActive(true);
    }

    public void Hide()
    {
        tooltipRoot.SetActive(false);
    }
}
