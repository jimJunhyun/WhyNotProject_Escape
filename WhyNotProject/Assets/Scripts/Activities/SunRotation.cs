using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ ���� ��� ������ �Ǿ������� ������� ����
/// ���� �ľ� �� ���� �ʿ�
/// </summary>
public class SunRotation : MonoBehaviour
{
    [SerializeField] private float dayMinute;
    private Light thisLight;
    private int passedDay;
    private float rotateAngle;

    void Start()
    {
        thisLight = GetComponent<Light>();
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

        if (transform.eulerAngles.x > -180 && transform.eulerAngles.x < -135)
        {
            if (thisLight.intensity != 0)
            {
                thisLight.intensity -= rotateAngle / 45 * Time.deltaTime;
            }
        }
        else if (transform.eulerAngles.x > -45 && transform.eulerAngles.x < 0)
        {
            if (thisLight.intensity < 1)
            {
                thisLight.intensity += rotateAngle / 45 * Time.deltaTime;
            }
        }
    }

    IEnumerator DayPass()
    {
        passedDay++;
        yield return new WaitForSeconds(dayMinute * 60);
        StartCoroutine(DayPass());
    }
}
