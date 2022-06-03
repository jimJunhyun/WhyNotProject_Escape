using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] private float dayMinute;
    private int dayPassed = 1;
    private float rotateAngle;

    private void Update()
    {
        rotateAngle = 360 / (dayMinute * 60);
        
        transform.Rotate(new Vector3(rotateAngle, 0, 0) * Time.deltaTime);
    }
}
