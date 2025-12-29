using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;



public class InfluenceUpgradeManager : MonoBehaviour
{   
    private List<InfluenceUpgrade> unlockedUpgrades = new List<InfluenceUpgrade>();
    bool passiveUpgradeClaimed = false;
    bool maskPassiveClaimed = false;
    float time;
    float timeInterval = 15f;
    float maskTime;
    float maskTimeInterval = 30f;
    public GameObject anvilButton;
    public bool checkPrereqs(InfluenceUpgrade upgrade)
    {
        //Debug.Log(upgrade.prereqs.Count);
        if (upgrade.prereqs.Count > 0)
        {
            foreach (InfluenceUpgrade i in upgrade.prereqs)
            {
                if (!unlockedUpgrades.Contains(i))
                {
                    Debug.Log("You dont meet the prereqs foo");

                    return false;
                }
            }
        }
        return true;
    }


    public bool unlockUpgrade(InfluenceUpgrade upgrade)
    {
        //Debug.Log(upgrade.upgradeName);
        if (checkPrereqs(upgrade))
        {
            if (ResourceManager.Instance.getInfluence() >= upgrade.influenceCost)
            {
                unlockedUpgrades.Add(upgrade);
                ResourceManager.Instance.spendInfluence(upgrade.influenceCost);
                applyUpgrade(upgrade);
                Debug.Log("Upgrade claimed!");
                return true;

            }
            else
            {
                Debug.Log("Brokey");
            }
        }
        return false;
    }

    public void applyUpgrade(InfluenceUpgrade upgrade)
    {
        ResourceManager.Instance.muxUpgradeBonus += upgrade.muxUpgrade;
        ResourceManager.Instance.influenceUpgradeBonus += upgrade.influenceUpgrade;
        ResourceManager.Instance.maskUpperBound = upgrade.maskUpperBound;
        anvilButton.GetComponent<Clicking>().setClicksPerMask(upgrade.lowerClickRate);
        if (upgrade.passiveInfluence && !passiveUpgradeClaimed)
        {
            ResourceManager.Instance.passiveInfluence += 1;
            passiveUpgradeClaimed = true;
        }
        if (upgrade.passiveMask && !maskPassiveClaimed)
        {
            maskPassiveClaimed = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;
        maskTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (passiveUpgradeClaimed)
        {
            time += Time.deltaTime;
            while (time >= timeInterval)
            {
                ResourceManager.Instance.setInfluence(ResourceManager.Instance.getInfluence() + 1);
                time -= timeInterval;
                ResourceManager.Instance.influenceDisplayLabel.text = "Influence: " + ResourceManager.Instance.getInfluence();
            }
        }
        if (maskPassiveClaimed)
        {
            maskTime += Time.deltaTime;
            while (maskTime >= maskTimeInterval)
            {
                ResourceManager.Instance.setMask(ResourceManager.Instance.getMask() + 1);
                maskTime -= maskTimeInterval;
                ResourceManager.Instance.maskDisplayLabel.text = "Mask: " + ResourceManager.Instance.getMask();
            }
        }

    }
}