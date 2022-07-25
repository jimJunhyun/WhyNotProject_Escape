using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private Light mainInnerLight;
    [SerializeField] private float dayMinute;
    [SerializeField] private float nightFogDensity;
    [SerializeField] private float fogDensityCalc;
    private int passedDay;
    private float rotateAngle;
    private float dayFogDensity;
    private float currentFogDensity;

    bool isNight;

    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
        StartCoroutine(DayPass());
    }

    void Update()
    {
        LightRotate();
    }

    private void LightRotate()
    {
        rotateAngle = 360 / (dayMinute * 60);

        transform.Rotate(new Vector3(rotateAngle, 0, 0) * Time.deltaTime);

        if (transform.eulerAngles.x >= 170)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }

            mainInnerLight.enabled = true;
        }
        else if (transform.eulerAngles.x <= 10)
        {
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }

            mainInnerLight.enabled = false;
        }
    }

    IEnumerator DayPass()
    {
        while (true)
        {
            passedDay++;
            yield return new WaitForSeconds(dayMinute * 60);
        }
    }
}
