using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    Vector3 mainCamera = new Vector3(0, 2, -10);
    Vector3 upgradeCamera = new Vector3(-14, 2, -10);
    bool isMovingCamera = false;
    Vector3 target;

    //muffle variables
    public AudioLowPassFilter muffleFilter;
    float muffleFreak = 300f;
    float normalFreak = 22000f;

    //spooky audio
    public AudioSource spookyAudio;

    public void portalButtonPress()
    {
        if (transform.position == mainCamera)
        {
            target = upgradeCamera;
            StartMuffle(muffleFreak);
            FadeUpgradeAudio(0.2f);
        }
        else
        {
            target = mainCamera;
            StartMuffle(normalFreak);
            FadeUpgradeAudio(0f);
        }
        isMovingCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMovingCamera)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, 30f * Time.deltaTime);


        if (Vector3.Distance(transform.position, target) < 0.01)
        {
            isMovingCamera = false;
        }

    }

    //for spooky audio
    void FadeUpgradeAudio(float targetVolume)
    {
        StartCoroutine(FadeAudioCoroutine(targetVolume));
    }

    IEnumerator FadeAudioCoroutine(float targetVolume)
    {
        float startVolume = spookyAudio.volume;
        float time = 0f;

        while (time < 0.2f)
        {
            spookyAudio.volume = Mathf.Lerp(startVolume, targetVolume, time / 0.2f);

            time += Time.deltaTime;
            yield return null;
        }

        spookyAudio.volume = targetVolume;
    }


    //muffle audio
    void StartMuffle(float targetFreq)
    {
        StopAllCoroutines();
        StartCoroutine(TransitionFilter(targetFreq));
    }


    IEnumerator TransitionFilter(float targetFreq)
    {
        float startFreq = muffleFilter.cutoffFrequency;
        float time = 0f;
        float duration = .2f;

        while (time < duration)
        {
            muffleFilter.cutoffFrequency = Mathf.Lerp(startFreq, targetFreq, time / duration);

            time += Time.deltaTime;
            yield return null;
        }

        muffleFilter.cutoffFrequency = targetFreq;
    }



}
