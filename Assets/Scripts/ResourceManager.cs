using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    [SerializeField] int muxs = 0;
    [SerializeField] int influence = 0;
    public TMP_Text muxsDisplayLabel;
    public TMP_Text influenceDisplayLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool editMuxsAndReturn(int amt)
    {
        if (muxs + amt < 0) return false;
        muxs += amt;
        muxsDisplayLabel.text = "Muxs:" + muxs;
        return true;
    }

    bool spendInfluence(int amt)
    {
        if (influence - amt < 0)
        {
            Debug.Log("Not enough for that!");
            return false;
        }

        influence -= amt;
        influenceDisplayLabel.text = "Influence:" + influence;
        return true;
    }

    void gainInfluence(int amt)
    {
        influence += amt;
        influenceDisplayLabel.text = "Influence:" + influence;
    }

    int getInfluence()
    {
        return influence;
    }

    int getMuxs()
    {
        return muxs;
    }

    void resourcesUpdate()
    {

    }

}
