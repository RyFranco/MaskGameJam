using System;
using TMPro;
using UnityEngine;

public class UpgradePanelScript : MonoBehaviour
{
    [Header("Upgrade Info")]
    [SerializeField] string UpgradeName = "upgrade";
    [SerializeField] int UpgradeCount = 0;


    [Header("Base Costs")]
    [SerializeField] int baseInfluenceCost = 0;
    [SerializeField] int baseMuxCost = 0;


    [Header("Current Costs")]
    [SerializeField] int InfluenceCost;
    [SerializeField] int MuxCost;

    [Header("")]
    [SerializeField] TMP_Text UpgradeNameText;
    [SerializeField] TMP_Text UpgradeCostText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InfluenceCost = baseInfluenceCost;
        MuxCost = baseMuxCost;
        UpgradeNameText.text = UpgradeName;
        UpgradeCostText.text = "$" + MuxCost;
    }



    public void TryToPurchase()
    {
        if(ResourceManager.Instance.getInfluence() < InfluenceCost) return;
        if(ResourceManager.Instance.getMuxs() < MuxCost) return;

        Purchase();

    }

    void Purchase()
    {
        ResourceManager.Instance.editMuxsAndReturn(-1 * MuxCost);
        UpgradeCount += 1;
        ChangePrice();
        UpgradeNameText.text = UpgradeName + " +" + UpgradeCount;

    }

    void ChangePrice()
    {
        InfluenceCost *=2;
        MuxCost *=2;
        UpgradeCostText.text = "$" + MuxCost;
        ResourceManager.Instance.Demand += 0.05f;
    }

}
