using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private float dayMinute;
    private Light sunLight;
    private int passedDay;
    private float rotateAngle;

    void Start()
    {
        sunLight = GetComponent<Light>();
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

        if (transform.localEulerAngles.x >= 315)
        {
            sunLight.intensity = (transform.localEulerAngles.x - 315) / 45;
        }
        else if (transform.localEulerAngles.x < 315 && transform.localEulerAngles.x >= 270)
        {
            sunLight.intensity = 0;
        }
        else
        {
            sunLight.intensity = 1;
        }
    }

    IEnumerator DayPass()
    {
        passedDay++;
        yield return new WaitForSeconds(dayMinute * 60);
        StartCoroutine(DayPass());
    }
}
