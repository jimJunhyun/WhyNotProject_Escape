using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        audioSource.volume = OptionUI.instance.SFXVolumeSlider.value;
    }
}
