using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private List<string> timeFlags;
    [SerializeField] private Light[] nightLight;
    [SerializeField] private Material[] lightMaterial;
    [SerializeField] private float dayMinute;
    private Light sunLight;
    private float passedDay;
    public float PassedDay
    {
        get { return passedDay; }
        set
        {
            passedDay = value;

            switch (passedDay)
            {
                case 0.5f:
                    if (!GameManager.instance.flags["InputCoin"])
                    {
                        CCManager.instance.CurrentCondition = timeFlags[0];
                    }

                    break;
                case 1f:
                    CCManager.instance.CurrentCondition = timeFlags[1];

                    break;
                case 1.5f:
                    CCManager.instance.CurrentCondition = timeFlags[2];
                    
                    break;
                case 2.5f:
                    CCManager.instance.CurrentCondition = timeFlags[3];
                    
                    break;
                case 3.5f:
                    CCManager.instance.CurrentCondition = timeFlags[4];
                    
                    break;
                case 5f:
                    CCManager.instance.CurrentCondition = timeFlags[5];
                    
                    break;
                case 6f:
                    CCManager.instance.CurrentCondition = timeFlags[6];
                    
                    break;
                case 7.5f:
                    CCManager.instance.CurrentCondition = timeFlags[7];
                    
                    break;
                default:
                    break;
            }
        }
    }
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
            yield return new WaitForSeconds(dayMinute * 15);

            PassedDay += 0.5f;
        }
    }
}
