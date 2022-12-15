using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundSettings : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text _volumeTextValue = null; //tetxt 0.0
    [SerializeField] private Slider _volumeslider = null; //slider dŸwiêku
    [SerializeField] private float _defaultVolume = 1.0f;

    public void SetVoulme(float volume)
    {
        AudioListener.volume = volume;
        _volumeTextValue.text = volume.ToString("0.0");
    }

    //zapisywanie po naciœnieciu apply, dodane na button apply
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }
}