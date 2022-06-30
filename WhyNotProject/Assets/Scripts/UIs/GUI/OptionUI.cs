using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform helpImageTransform;
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
    private bool helpImageOpened;

    private void Start()
    {
        bgmToggle.value = PlayerPrefs.GetFloat("BGMToggle", 1);

        if (bgmToggle.value == 1)
        {
            bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 100);
        }

        sfxToggle.value = PlayerPrefs.GetFloat("SFXToggle", 1);

        if (sfxToggle.value == 1)
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 100);
        }

        ccToggle.value = PlayerPrefs.GetFloat("CCToggle", 1);
        ccSpeedSlider.value = PlayerPrefs.GetFloat("CCSpeed", 50);
    }

    private void Update()
    {
        OptionOpenClose();
        TextUI();
    }

    private void OptionOpenClose()
    {
        if (Input.GetKeyDown(KeyCode.O) && optionOpened == false)
        {
            optionOpened = true;
            rectTransform.DOAnchorPosY(0, 1f).SetUpdate(true);
            Time.timeScale = 0.0f;
        }
        else if (Input.GetKeyDown(KeyCode.O) && optionOpened == true)
        {
            optionOpened = false;
            rectTransform.DOAnchorPosY(450, 1f).SetUpdate(true);
            Time.timeScale = 1.0f;
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

            PlayerPrefs.SetFloat("BGMToggle", bgmToggle.value);
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

            PlayerPrefs.SetFloat("SFXToggle", sfxToggle.value);
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

        PlayerPrefs.SetFloat("CCToggle", ccToggle.value);
    }

    public void BGMSliderChange()
    {
        sliderChanged = true;

        if (toggleChanged == false)
        {
            PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);

            bgmToggle.value = Mathf.Ceil(bgmVolumeSlider.value);

            if (bgmToggle.value == 0)
            {
                bgmToggleEnabled = false;
            }
            else
            {
                bgmToggleEnabled = true;
            }

            PlayerPrefs.SetFloat("BGMToggle", bgmToggle.value);
        }

        sliderChanged = false;
    }

    public void SFXSliderChange()
    {
        sliderChanged = true;

        if (toggleChanged == false)
        {
            PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);

            sfxToggle.value = Mathf.Ceil(sfxVolumeSlider.value);

            if (sfxToggle.value == 0)
            {
                sfxToggleEnabled = false;
            }
            else
            {
                sfxToggleEnabled = true;
            }

            PlayerPrefs.SetFloat("SFXToggle", sfxToggle.value);
        }

        sliderChanged = false;
    }

    public void CCSliderChange()
    {
        sliderChanged = true;

        if (toggleChanged == false)
        {
            PlayerPrefs.SetFloat("CCSpeed", ccSpeedSlider.value);
        }

        sliderChanged = false;
    }

    public void HelpImagePopup()
    {
        if (helpImageOpened == false)
        {
            helpImageTransform.DOScale(new Vector2(1, 1), 1f).SetUpdate(true);
            helpImageOpened = true;
        }
        else
        {
            helpImageTransform.DOScale(new Vector2(0, 0), 1f).SetUpdate(true);
            helpImageOpened = false;
        }
    }
}
