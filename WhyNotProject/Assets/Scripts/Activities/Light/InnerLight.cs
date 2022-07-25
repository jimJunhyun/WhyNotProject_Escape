using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLight : MonoBehaviour
{
    private Light mainInnerLight;
    private Transform sunTransform;

    private void Start()
    {
        sunTransform = GameObject.Find("Sun").GetComponent<Transform>();
        mainInnerLight = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        LightOnOff();
    }

    private void LightOnOff()
    {
        if (sunTransform.eulerAngles.x >= 170)
        {
            mainInnerLight.enabled = true;
        }
        else
        {
            mainInnerLight.enabled = false;
        }
    }
}
