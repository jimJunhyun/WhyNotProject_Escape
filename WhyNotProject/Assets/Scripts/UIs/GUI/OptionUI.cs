using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public static OptionUI instance;

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform helpImageTransform;
    [SerializeField] private Slider bgmToggle;
    [SerializeField] private Slider bgmVolumeSlider;
    public Slider BGMVolumeSlider => bgmVolumeSlider;
    [SerializeField] private Slider sfxToggle;
    [SerializeField] private Slider sfxVolumeSlider;
    public Slider SFXVolumeSlider => sfxVolumeSlider;
    [SerializeField] private Slider ccToggle;
    [SerializeField] private TextMeshProUGUI bgmCurrentVolume;
    [SerializeField] private TextMeshProUGUI sfxCurrentVolume;
    [SerializeField] private TextMeshProUGUI ccText;
    public bool optionOpened;
    private bool toggleChanged;
    private bool sliderChanged;
    private bool helpImageOpened;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 100);
        bgmToggle.value = Mathf.Ceil(bgmVolumeSlider.value);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 100);
        sfxToggle.value = Mathf.Ceil(sfxVolumeSlider.value);
        ccToggle.value = PlayerPrefs.GetFloat("CCToggle", 1);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene" && !Input.GetKeyDown(KeyCode.O) && !optionOpened)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("PlayScene");
            }
        }

        ccText.gameObject.SetActive(ccToggle.value != 0);

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
            if (helpImageOpened == true)
            {
                helpImageOpened = false;
                helpImageTransform.DOScale(new Vector2(0, 0), 1f).SetUpdate(true);
            }

            optionOpened = false;
            rectTransform.DOAnchorPosY(450, 1f).SetUpdate(true);
            Time.timeScale = 1.0f;
        }
    }

    private void TextUI()
    {
        bgmCurrentVolume.text = $"{Mathf.Floor(bgmVolumeSlider.value * 100)}";
        sfxCurrentVolume.text = $"{Mathf.Floor(sfxVolumeSlider.value * 100)}";
    }

    public void BGMToggleChange()
    {
        toggleChanged = true;

        if (sliderChanged == false)
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
                PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
                sfxVolumeSlider.value = 0;
            }
            else
            {
                sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
            }
        }

        toggleChanged = false;
    }

    public void CCToggleChange()
    {
        PlayerPrefs.SetFloat("CCToggle", ccToggle.value);
    }

    public void BGMSliderChange()
    {
        sliderChanged = true;

        if (toggleChanged == false)
        {
            PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);

            bgmToggle.value = Mathf.Ceil(bgmVolumeSlider.value);
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
        }

        sliderChanged = false;
    }

    public void HelpImagePopup()
    {
        if (helpImageOpened == false)
        {
            helpImageOpened = true;
            helpImageTransform.DOScale(new Vector2(1, 1), 1f).SetUpdate(true);
        }
        else
        {
            helpImageOpened = false;
            helpImageTransform.DOScale(new Vector2(0, 0), 1f).SetUpdate(true);
        }
    }

    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
