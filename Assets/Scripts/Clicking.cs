using UnityEngine;

public class Clicking : MonoBehaviour
{
    [SerializeField] int totalClicksForMask = 10;
    [SerializeField] int totalMasks;
    private int numberOfMaskClicks = 0;
    public void ButtonPressed()
    {
        Debug.Log("We smithin!");
        numberOfMaskClicks++;
        if (numberOfMaskClicks >= totalClicksForMask)
        {
            Debug.Log("Mask Created!");
            totalMasks++;
            numberOfMaskClicks = 0;
        } 
    }    
}