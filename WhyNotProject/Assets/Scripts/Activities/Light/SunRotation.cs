using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private Light[] nightLight;
    [SerializeField] private Material[] lightMaterial;
    [SerializeField] private float dayMinute;
    private int passedDay;
    private float rotateAngle;

    void Start()
    {
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
            for (int i = 0; i < nightLight.Length; i++)
            {
                nightLight[i].enabled = true;
            }

            for (int i = 0; i < lightMaterial.Length; i++)
            {
                lightMaterial[i].SetColor("_EmissionColor", (i == 0 ? new Color(231, 213, 63, 255) : new Color(231, 231, 231, 255)) * 1f);
            }
        }
        else if (transform.eulerAngles.x <= 10)
        {
            for (int i = 0; i < nightLight.Length; i++)
            {
                nightLight[i].enabled = false;
            }

            for (int i = 0; i < lightMaterial.Length; i++)
            {
                lightMaterial[i].SetColor("_EmissionColor", (i == 0 ? new Color(231, 213, 63, 255) : new Color(231, 231, 231, 255)) * 0f);
            }
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
