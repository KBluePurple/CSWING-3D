using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer masterMixer;
    [SerializeField]
    private Slider audioSlider;

    public void AudioController()
    {
        float sound = audioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("사운드 이름", 80);
        }
        else
        {
            masterMixer.SetFloat("사운드 이름", sound);
        }
    }
}
