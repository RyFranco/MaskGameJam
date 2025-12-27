using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    [SerializeField] int muxs = 0;
    [SerializeField] int influence = 0;
        


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

    bool editMuxsAndReturn(int amt)
    {
        if (muxs + amt < 0) return false;
        muxs += amt;
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
        return true;
    }

    void gainInfulence(int amt)
    {
        influence += amt;
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
