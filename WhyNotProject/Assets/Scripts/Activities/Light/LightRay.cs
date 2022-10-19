using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LightRay : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        RaycastHit paperHit;

        if (SunRotation.isNight)
        {
            if (Physics.Raycast(new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f), mainCamera.transform.position - new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f), out paperHit, 2.5f, 1 << 2))
            {
                if (paperHit.collider.gameObject.CompareTag("Paper"))
                {
                    paperHit.collider.gameObject.GetComponent<MeshRenderer>().material = materials[1];
                }
                else
                {
                    paperHit.collider.gameObject.GetComponent<MeshRenderer>().material = materials[0];
                }
            }

            Debug.DrawRay(new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f), (mainCamera.transform.position - new Vector3(transform.position.x, GetComponent<Renderer>().bounds.max.y - 0.1f)) * 2.5f, Color.red);
        }
    }
}
