using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InfluenceUpgrade upgradeInfo;
    public InfluenceUpgradeManager manager;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (upgradeInfo != null) TextUIHover.Instance.Show(upgradeInfo.Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextUIHover.Instance.Hide();
    }

    public void OnClick(InfluenceUpgrade upgrade)
    {
        if (manager.unlockUpgrade(upgrade))
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
  
