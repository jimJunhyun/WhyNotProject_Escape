using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour
{
    [SerializeField] private LayerMask paperLayer;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (SunRotation.isNight)
        {
            if (Physics.Raycast(new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f), mainCamera.transform.position - new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f), 2.5f, paperLayer))
            {
                //텍스쳐 바꾸기
            }

            Debug.DrawRay(new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f), (mainCamera.transform.position - new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f)) * 2.5f, Color.red);
        }
    }
}
