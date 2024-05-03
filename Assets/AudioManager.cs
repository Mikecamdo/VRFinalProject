using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip background1;
    public AudioClip background2;
    public AudioClip background3;
    public AudioClip background4;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    public float switchDuration = 10f;

    void Start()
    {
        PlayBackgroundAudio(background1, audioSource1);
        StartCoroutine(SwitchAudioSources());
    }

    IEnumerator SwitchAudioSources()
    {
        // Start by waiting for the specified duration
        yield return new WaitForSeconds(switchDuration);

        // Determine which audio source is currently playing and switch to the next one
        if (audioSource1.isPlaying)
        {
            PlayNextBackgroundAudio(audioSource1, audioSource2, background2);
            StopBackgroundAudio(audioSource1);
        }
        else if (audioSource2.isPlaying)
        {
            PlayNextBackgroundAudio(audioSource2, audioSource3, background3);
            StopBackgroundAudio(audioSource2);
        }
        else if (audioSource3.isPlaying)
        {
            PlayNextBackgroundAudio(audioSource3, audioSource4, background4);
            StopBackgroundAudio(audioSource3);
        }
        else if (audioSource4.isPlaying)
        {
            PlayNextBackgroundAudio(audioSource4, audioSource1, background1);
            StopBackgroundAudio(audioSource4);
        }

        // Start the coroutine again for the next switch
        StartCoroutine(SwitchAudioSources());
    }

    void PlayBackgroundAudio(AudioClip clip, AudioSource source)
    {
        source.clip = clip;
        source.Play();
    }

    void PlayNextBackgroundAudio(AudioSource currentSource, AudioSource nextSource, AudioClip nextClip)
    {
        nextSource.clip = nextClip;
        nextSource.Play();
    }

    void StopBackgroundAudio(AudioSource source)
    {
        source.Stop();
    }
}
