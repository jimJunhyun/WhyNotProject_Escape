using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Slider bgmToggle;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider sfxToggle;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider ccToggle;
    [SerializeField] private Slider ccSpeedSlider;
    [SerializeField] private TextMeshProUGUI bgmCurrentVolume;
    [SerializeField] private TextMeshProUGUI sfxCurrentVolume;
    [SerializeField] private TextMeshProUGUI ccCurrentSpeed;
    public bool optionOpened;
    public bool bgmToggleEnabled;
    public bool sfxToggleEnabled;
    public bool ccToggleEnabled;
    private bool toggleChanged;
    private bool sliderChanged;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        OptionOpenClose();
        TextUI();
    }

    private void OptionOpenClose()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionOpened == false)
        {
            optionOpened = true;
            rectTransform.DOAnchorPosY(0, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && optionOpened == true)
        {
            optionOpened = false;
            rectTransform.DOAnchorPosY(450, 1f);
        }
    }

    private void TextUI()
    {
        bgmCurrentVolume.text = $"{Mathf.Floor(bgmVolumeSlider.value * 100)}";
        sfxCurrentVolume.text = $"{Mathf.Floor(sfxVolumeSlider.value * 100)}";
        ccCurrentSpeed.text = $"{Mathf.Floor(ccSpeedSlider.value * 100)}";
    }

    public void BGMToggleChange()
    {
        toggleChanged = true;

        if (sliderChanged == false)
        {
            if (bgmToggle.value == 0)
            {
                bgmToggleEnabled = false;
                PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);
                bgmVolumeSlider.value = 0;
            }
            else
            {
                bgmToggleEnabled = true;
                bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1);
            }
        }

        toggleChanged = false;
    }

    public void SFXToggleChange()
    {
        toggleChanged = true;

        if (sliderChanged == false)
        {
            if (sfxToggle.value == 0)
            {
                sfxToggleEnabled = false;
                PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
                sfxVolumeSlider.value = 0;
            }
            else
            {
                sfxToggleEnabled = true;
                sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
            }
        }

        toggleChanged = false;
    }

    public void CCToggleChange()
    {
        if (ccToggle.value == 0)
        {
            ccToggleEnabled = false;
        }
        else
        {
            ccToggleEnabled = true;
        }
    }

    public void BGMSliderChange()
    {
        sliderChanged = true;

        if (toggleChanged == false)
        {
            if (bgmVolumeSlider.value == 0)
            {
                PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);
            }

            bgmToggle.value = Mathf.Ceil(bgmVolumeSlider.value);

            if (bgmToggle.value == 0)
            {
                bgmToggleEnabled = false;
            }
            else
            {
                bgmToggleEnabled = true;
            }
        }

        sliderChanged = false;
    }

    public void SFXSliderChange()
    {
        sliderChanged = true;

        if (toggleChanged == false)
        {
            if (sfxVolumeSlider.value == 0)
            {
                PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
            }

            sfxToggle.value = Mathf.Ceil(sfxVolumeSlider.value);

            if (sfxToggle.value == 0)
            {
                sfxToggleEnabled = false;
            }
            else
            {
                sfxToggleEnabled = true;
            }
        }

        sliderChanged = false;
    }
}
