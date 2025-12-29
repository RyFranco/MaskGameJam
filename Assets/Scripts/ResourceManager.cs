using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Data;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    [SerializeField] int muxs = 0;
    [SerializeField] int influence = 0;
    [SerializeField] int mask = 0;
    [SerializeField] public float Demand = 1f;
    public int passiveInfluence = 0;


    //Player Upgrade Stats
    public int muxUpgradeBonus = 0;
    public int influenceUpgradeBonus = 0;
    public int maskUpperBound = 0;

    public TMP_Text muxsDisplayLabel;
    public TMP_Text influenceDisplayLabel;
    public TMP_Text maskDisplayLabel;

    public List<Sprite> MaskSpritesForSale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        muxsDisplayLabel.text = "Muxs: " + muxs;
        influenceDisplayLabel.text = "Influence: " + influence;
        maskDisplayLabel.text = "Mask: " + mask;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool editMuxsAndReturn(int amt)
    {
        if (muxs + amt < 0) return false;
        muxs += (amt + muxUpgradeBonus);
        muxsDisplayLabel.text = "Muxs: " + muxs;
        return true;
    }

    public bool spendInfluence(int amt)
    {
        if (influence - amt < 0)
        {
            Debug.Log("Not enough for that!");
            return false;
        }

        influence -= amt;
        influenceDisplayLabel.text = "Influence: " + influence;
        return true;
    }

    public void gainInfluence(int amt)
    {
        influence += (amt + influenceUpgradeBonus);
        influenceDisplayLabel.text = "Influence: " + influence;
    }

    public void gainMasks(int amt)
    {
        mask += amt;
        maskDisplayLabel.text = "Mask: " + mask;
    }

    public bool spendMasks(int amt)
    {
        if (mask - amt < 0)
        {
            Debug.Log("Not enough for that!");
            return false;
        }
        //Mask refund logic
        if (Random.Range(1, maskUpperBound + 1) != 4)
        {
            mask -= amt;
            maskDisplayLabel.text = "Mask: " + mask;
            gainInfluence(1);
            editMuxsAndReturn(10);
            return true;
        }
        Debug.Log("Mask refunded!");
        
        return true;
    }

    public int getInfluence()
    {
        return influence;
    }
    public void setInfluence(int amt)
    {
        influence = amt;
    }

    public int getMuxs()
    {
        return muxs;
    }

    public int getMask()
    {
        return mask;
    }

    public void setMask(int amt)
    {
        mask = amt;
    }

    void resourcesUpdate()
    {

    }

}
