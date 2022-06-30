using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLight : MonoBehaviour
{
    private Light mainInnerLight;
    private Transform sunRotation;

    private void Start()
    {
        sunRotation = GameObject.Find("Sun").GetComponent<Transform>();
        mainInnerLight = GetComponent<Light>();
    }

    private void Update()
    {
        LightOnOff();
    }

    private void LightOnOff()
    {
        if (sunRotation.localEulerAngles.x <= 270)
        {
            mainInnerLight.enabled = false;
        }
        else
        {
            mainInnerLight.enabled = true;
        }
    }
}
