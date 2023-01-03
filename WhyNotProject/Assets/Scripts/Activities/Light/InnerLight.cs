using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLight : MonoBehaviour
{
    [SerializeField] private Material lightMaterial;
    [SerializeField] private Material paperMaterial;
    public bool isLightOn;
    private Light innerLight;

    private void Awake()
    {
        innerLight = GetComponent<Light>();
        paperMaterial.color = Color.white;
    }

    private void Start()
    {
        isLightOn = false;
        innerLight.enabled = false;

        lightMaterial.SetColor("_EmissionColor", Color.black);

        paperMaterial.color = Color.white;
    }

    public void LightOnOff()
    {
        GameManager.instance.FirstLightOn();

        if (!isLightOn)
        {
            isLightOn = true;
            innerLight.enabled = true;

            lightMaterial.SetColor("_EmissionColor", Color.white);

            paperMaterial.color = new Color(1f, 1f, 1f, 225f / 255f);
        }
        else
        {
            isLightOn = false;
            innerLight.enabled = false;

            lightMaterial.SetColor("_EmissionColor", Color.black);

            paperMaterial.color = Color.white;
        }
    }
}
