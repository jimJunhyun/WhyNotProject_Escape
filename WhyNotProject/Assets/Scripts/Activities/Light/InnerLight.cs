using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLight : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Light mainInnerLight;
    private Transform sunRotation;

    private void Start()
    {
        sunRotation = GameObject.Find("Sun").GetComponent<Transform>();
        meshRenderer = GetComponent<MeshRenderer>();
        mainInnerLight = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        LightOnOff();
    }

    private void LightOnOff()
    {
        if (sunRotation.localEulerAngles.x <= 200)
        {
            mainInnerLight.enabled = false;
        }
        else
        {
            mainInnerLight.enabled = true;
        }
    }
}
