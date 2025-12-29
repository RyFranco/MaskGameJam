using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InfluenceUpgrade upgradeInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (upgradeInfo != null) TextUIHover.Instance.Show(upgradeInfo.Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextUIHover.Instance.Hide();
    }
}
  
