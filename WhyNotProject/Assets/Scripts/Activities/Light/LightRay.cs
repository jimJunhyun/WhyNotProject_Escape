using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask paperLayer;

    private void Update()
    {
        if (SunRotation.isNight)
        {
            RaycastHit2D paperHit = Physics2D.Raycast(transform.position, mainCamera.transform.position - transform.position, Mathf.Infinity, paperLayer);

            if (paperHit)
            {
                //텍스쳐 바꾸기
            }

            Debug.DrawRay(transform.position, (mainCamera.transform.position - transform.position) * Mathf.Infinity, Color.red);
        }
    }
}
