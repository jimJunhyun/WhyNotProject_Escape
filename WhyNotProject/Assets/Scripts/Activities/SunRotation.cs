using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 태양 회전 시 오브젝트 밝기 조절 수정
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
        StartCoroutine(LightRedInc());
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
    }

    IEnumerator LightRedInc()
    {
        yield return new WaitForSeconds(dayMinute * 30);
        if (thisLight.intensity != 0)
            thisLight.intensity -= rotateAngle / 45 * Time.deltaTime;
        yield return new WaitForSeconds(dayMinute * 15);
        if (thisLight.intensity < 1)
            thisLight.intensity += rotateAngle / 45 * Time.deltaTime;
        StartCoroutine(LightRedInc());
    }

    IEnumerator DayPass()
    {
        passedDay++;
        yield return new WaitForSeconds(dayMinute * 60);
        StartCoroutine(DayPass());
    }
}
