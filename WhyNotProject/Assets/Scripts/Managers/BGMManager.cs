using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        audioSource.volume = OptionUI.instance.BGMVolumeSlider.value;
    }
}
