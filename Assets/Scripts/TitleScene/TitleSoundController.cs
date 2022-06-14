using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TitleSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer masterMixer;
    [SerializeField]
    private Slider audioSlider;

    public void AudioController(string mixerName)
    {
        float sound = audioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat(mixerName, -80);
        }
        else
        {
            masterMixer.SetFloat(mixerName, sound);
        }
    }
}
