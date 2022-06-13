using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();

    private AudioSource audioSource = null;

    private Dictionary<string, AudioClip> soundList = null;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        soundList = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in audioClips)
        {
            soundList.Add(audioClip.name, audioClip);
        }
    }

    public void PlaySound(string soundName, SoundType soundType = SoundType.SE)
    {
        if (soundList.ContainsKey(soundName))
        {
            if (soundType == SoundType.SE)
            {
                audioSource.PlayOneShot(soundList[soundName]);
            }
            else if (soundType == SoundType.BGM)
            {
                audioSource.clip = soundList[soundName];
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }
}
