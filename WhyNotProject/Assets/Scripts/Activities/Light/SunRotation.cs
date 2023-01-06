using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private List<string> timeFlags;
    [SerializeField] private Light[] nightLight;
    [SerializeField] private Material[] lightMaterial;
    [SerializeField] private float dayMinute;
    private Light sunLight;
    private InnerLight innerLight;
    public static float passedDay;
    public float PassedDay
    {
        get { return passedDay; }
        set
        {
            passedDay = value;

            switch (passedDay)
            {
                case 0.25f:
                    if (!GameManager.instance.flags["InputCoin"])
                    {
                        CCManager.instance.CurrentCondition = timeFlags[timeFlags.IndexOf("CoinInduce")];
                    }

                    break;
                case 1.5f:
                case 2.5f:
                case 3.5f:
                case 5f:
                case 6.5f:
                case 7.5f:
                case 8.5f:
                case 10f:
                    if (!GameManager.instance.flags["End"])
                    {
                        CCManager.instance.CurrentCondition = timeFlags[timeFlags.IndexOf($"{passedDay * dayMinute}minAgo")];
                    }
                    
                    break;
                default:
                    break;
            }
        }
    }
    private float rotateAngle;
    private bool isNight;
    public bool IsNight
    {
        get { return isNight; }
        set
        {
            isNight = value;

            innerLight.LightOnOff();
        }
    }

    private void Start()
    {
        passedDay = 0f;
        sunLight = GetComponent<Light>();
        innerLight = FindObjectOfType<InnerLight>();

        StartCoroutine(DayPass());
    }

    private void Update()
    {
        LightRotate();
    }

    private void LightRotate()
    {
        rotateAngle = 360 / (dayMinute * 60);

        transform.Rotate(new Vector3(rotateAngle, 0, 0) * Time.deltaTime);

        if (transform.eulerAngles.x >= 170)
        {
            if (!isNight && sunLight.intensity != 0)
            {
                IsNight = true;

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
        }
        else if (transform.eulerAngles.x <= 10)
        {
            if (isNight && sunLight.intensity == 0)
            {
                IsNight = false;

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
    }

    private IEnumerator DayPass()
    {
        while (true)
        {
            yield return new WaitForSeconds(dayMinute * 15f);

            PassedDay += 0.25f;
        }
    }
}
