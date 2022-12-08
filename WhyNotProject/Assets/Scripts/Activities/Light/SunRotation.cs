using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private Light[] nightLight;
    [SerializeField] private Material[] lightMaterial;
    [SerializeField] private float dayMinute;
    private Light sunLight;
    private int passedDay;
    private float rotateAngle;
    private bool isNight;
    public bool IsNight => isNight;

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

        if (transform.eulerAngles.x >= 170)
        {
            isNight = true;

            for (int i = 0; i < nightLight.Length; i++)
            {
                nightLight[i].enabled = true;
            }

            for (int i = 0; i < lightMaterial.Length; i++)
            {
                lightMaterial[i].SetColor("_EmissionColor", Color.white);
            }

            sunLight.intensity = 0;
        }
        else if (transform.eulerAngles.x <= 10)
        {
            isNight = false;

            for (int i = 0; i < nightLight.Length; i++)
            {
                nightLight[i].enabled = false;
            }

            for (int i = 0; i < lightMaterial.Length; i++)
            {
                lightMaterial[i].SetColor("_EmissionColor", Color.black);
            }

            sunLight.intensity = 1;
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
