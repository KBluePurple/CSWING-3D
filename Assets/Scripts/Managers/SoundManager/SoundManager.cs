using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [Header("오디오 소스")]
    [SerializeField]
    private AudioSource BMGAudioSource = null;
    [SerializeField]
    private AudioSource SEAudioSource = null;


    [SerializeField]
    private List<AudioClip> audioClips = new List<AudioClip>();


    private Dictionary<string, AudioClip> soundList = null;

    void Awake()
    {
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
                SEAudioSource.PlayOneShot(soundList[soundName]);
            }
            else if (soundType == SoundType.BGM)
            {
                if (BMGAudioSource.isPlaying)
                {
                    BMGAudioSource.Stop();
                }
                BMGAudioSource.clip = soundList[soundName];
                BMGAudioSource.loop = true;
                BMGAudioSource.Play();
            }
        }
    }
}
