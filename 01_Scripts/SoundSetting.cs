using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    [SerializeField] private AudioMixer _audioMixer;

    private string master = "Master";
    private string bgm = "Music";
    private string sfx = "SFX";

    public void MasterVolume()
    {
        float volume = _masterSlider.value;
        _audioMixer.SetFloat(master, volume);
    }
    public void BgmVolume()
    {
        float volume = _bgmSlider.value;
        _audioMixer.SetFloat(bgm, volume);
    }
    public void SfxVolume()
    {
        float volume = _sfxSlider.value;
        _audioMixer.SetFloat(sfx, volume);
    }
}
