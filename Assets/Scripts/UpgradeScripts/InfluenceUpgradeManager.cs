using UnityEngine;
using System.Collections.Generic;


public class InfluenceUpgradeManager : MonoBehaviour
{   
    private List<InfluenceUpgrade> unlockedUpgrades = new List<InfluenceUpgrade>();
    bool passiveUpgradeClaimed = false;
    float time;
    float timeInterval = 30f;
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


    public void unlockUpgrade(InfluenceUpgrade upgrade)
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
            }
            else
            {
                Debug.Log("Brokey");

            }
        }
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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;
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

    }
}
