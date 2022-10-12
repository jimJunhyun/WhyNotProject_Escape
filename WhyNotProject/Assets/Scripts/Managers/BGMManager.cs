using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        audioSource.volume = OptionUI.instance.BGMVolumeSlider.value;
    }
}
