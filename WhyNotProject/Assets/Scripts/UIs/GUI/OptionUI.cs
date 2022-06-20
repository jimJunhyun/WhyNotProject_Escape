using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �����̴��� �巡���ؼ� ���� 0�� ����� �ٽ� ���� ������� ����
/// </summary>
public class OptionUI : MonoBehaviour
{
    public bool optionOpened;
    [SerializeField] private Slider bgmToggle;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider sfxToggle;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider ccToggle;
    [SerializeField] private TextMeshProUGUI bgmCurrentVolume;
    [SerializeField] private TextMeshProUGUI sfxCurrentVolume;

    private void Update()
    {
        TextUI();
    }

    public void ToggleUI()
    {
        if (bgmToggle.value == 0)
        {
            PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);
            bgmVolumeSlider.value = 0;
        }
        else
        {
            bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1);
        }

        if (sfxToggle.value == 0)
        {
            PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
            sfxVolumeSlider.value = 0;
        }
        else
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
        }
    }

    public void SliderUI()
    {
        bgmToggle.value = Mathf.Ceil(bgmVolumeSlider.value);
        sfxToggle.value = Mathf.Ceil(sfxVolumeSlider.value);
    }

    private void TextUI()
    {
        bgmCurrentVolume.text = $"{Mathf.Floor(bgmVolumeSlider.value * 100)}";
        sfxCurrentVolume.text = $"{Mathf.Floor(sfxVolumeSlider.value * 100)}";
    }
}
