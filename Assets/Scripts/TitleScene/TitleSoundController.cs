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
    private Slider bgmSlider;
    [SerializeField]
    private Slider seSlider;

    public void BGMVolumeChange()
    {
        masterMixer.SetFloat("BGM", bgmSlider.value);
    }

    public void SEVolumeChange()
    {
        masterMixer.SetFloat("SE", seSlider.value);
    }
}
