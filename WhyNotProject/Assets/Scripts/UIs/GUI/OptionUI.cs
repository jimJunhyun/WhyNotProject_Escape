using DG.Tweening;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public static OptionUI instance;

    [SerializeField] private GameObject page1;
    [SerializeField] private GameObject page2;
    [SerializeField] private GameObject logTextPrefab;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform logRectTransform;
    [SerializeField] private RectTransform logContent;
    [SerializeField] private Slider bgmToggle;
    [SerializeField] private Slider bgmVolumeSlider;
    public Slider BGMVolumeSlider => bgmVolumeSlider;
    [SerializeField] private Slider sfxToggle;
    [SerializeField] private Slider sfxVolumeSlider;
    public Slider SFXVolumeSlider => sfxVolumeSlider;
    [SerializeField] private TextMeshProUGUI bgmCurrentVolume;
    [SerializeField] private TextMeshProUGUI sfxCurrentVolume;
    public bool optionOpened;
    public bool logOpened;
    private bool toggleChanged;
    private bool sliderChanged;
    private int logCount;

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
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.O) && !optionOpened)
        {
            if (SceneManager.GetActiveScene().name == "StartScene")
            {
                if (logCount > 0)
                {
                    for (; logCount > 0; logCount--)
                    {
                        Destroy(logContent.GetChild(logCount - 1).gameObject);
                    }

                    CCManager.instance.outputCaptions.Clear();
                }

                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }

        OptionOpenClose();
        TextUI();
    }

    private void OptionOpenClose()
    {
        if (!optionOpened && !logOpened)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                optionOpened = true;

                rectTransform.DOAnchorPosY(0, 1f).SetUpdate(true);

                Time.timeScale = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.L) && SceneManager.GetActiveScene().name != "StartScene")
            {
                optionOpened = true;
                logOpened = true;

                logRectTransform.DOAnchorPosY(0, 1f).SetUpdate(true);

                for (int i = logCount; i < CCManager.instance.outputCaptions.Count; i++)
                {
                    GameObject logText = Instantiate(logTextPrefab);

                    logText.transform.SetParent(logContent);

                    logText.transform.localScale = Vector3.one;
                    logText.GetComponent<TextMeshProUGUI>().text = CCManager.instance.outputCaptions[i];
                }

                logCount = CCManager.instance.outputCaptions.Count;

                Time.timeScale = 0.0f;
            }
        }
        else if (optionOpened)
        {
            if (Input.GetKeyDown(KeyCode.O) && !logOpened)
            {
                optionOpened = false;

                rectTransform.DOAnchorPosY(450, 1f).SetUpdate(true);

                Time.timeScale = 1.0f;
            }
            else if (Input.GetKeyDown(KeyCode.L) && logOpened)
            {
                optionOpened = false;
                logOpened = false;

                logRectTransform.DOAnchorPosY(450, 1f).SetUpdate(true);

                Time.timeScale = 1.0f;
            }
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

    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

    public void PageChange()
    {
        if (page1.activeInHierarchy)
        {
            page2.SetActive(true);
            page1.SetActive(false);
        }
        else
        {
            page1.SetActive(true);
            page2.SetActive(false);
        }
    }
}
