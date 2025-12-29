using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    [SerializeField] int muxs = 0;
    [SerializeField] int influence = 0;
    [SerializeField] int mask = 0;

    //Player Upgrade Stats
    public int muxUpgradeBonus = 0;
    public int influenceUpgradeBonus = 0;

    public TMP_Text muxsDisplayLabel;
    public TMP_Text influenceDisplayLabel;
    public TMP_Text maskDisplayLabel;



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

        mask -= amt;
        maskDisplayLabel.text = "Mask: " + mask;
        return true;
    }

    public int getInfluence()
    {
        return influence;
    }

    public int getMuxs()
    {
        return muxs;
    }

    void resourcesUpdate()
    {

    }

}
