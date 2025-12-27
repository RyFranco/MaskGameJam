using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    private int muxs = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(GameObject);
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

    int getMuxs()
    {
        return muxs;
    }
}
