using UnityEngine;

public class Clicking : MonoBehaviour
{
    [SerializeField] int totalClicksForMask = 10;
    private int numberOfMaskClicks = 0;
    public AudioSource craftingAudio;
    public AudioSource FinishAudio;

    public void ButtonPressed()
    {
        Debug.Log(numberOfMaskClicks);
        if (numberOfMaskClicks % 2 == 0 )
        {
            craftingAudio.PlayOneShot(craftingAudio.clip); 
        }

        numberOfMaskClicks++;
        if (numberOfMaskClicks >= totalClicksForMask)
        {
            FinishAudio.PlayOneShot(FinishAudio.clip);
            //Debug.Log("Mask Created!");
            ResourceManager.Instance.gainMasks(1);
            numberOfMaskClicks = 0;
        }
    }
    public void setClicksPerMask(int numberOfMaskClicks)
    {
        totalClicksForMask = numberOfMaskClicks;
    }
}