using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLight : MonoBehaviour
{
    [SerializeField] private Material lightMaterial;
    [SerializeField] private Material paperMaterial;
    [SerializeField] private LeverUpDown leverUpDown;
    public bool isLightOn;
    private Light innerLight;
    private SunRotation sunRotation;

    private void Awake()
    {
        innerLight = GetComponent<Light>();
        sunRotation = GameObject.Find("Sun").GetComponent<SunRotation>();
        paperMaterial.color = Color.white;
    }

    private void Start()
    {
        LightOnOff();
    }

    public void LightOnOff()
    {
        if ((leverUpDown.state == 1 && sunRotation.IsNight) || leverUpDown.state == 2)
        {
            isLightOn = true;
            innerLight.enabled = true;

            lightMaterial.EnableKeyword("_EMISSION");

            paperMaterial.color = new Color(1f, 1f, 1f, 225f / 255f);
        }
        else if ((leverUpDown.state == 1 && !sunRotation.IsNight) || leverUpDown.state == 0)
        {
            isLightOn = false;
            innerLight.enabled = false;

            lightMaterial.DisableKeyword("_EMISSION");

            paperMaterial.color = Color.white;
        }

        if (isLightOn)
        {
            GameManager.instance.FirstLightOn();
        }
    }
}
