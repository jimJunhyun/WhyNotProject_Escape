using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLightRay : MonoBehaviour
{
    [SerializeField] private LayerMask heldLayer;
    [SerializeField] private float rayDistance;
    private GameObject player;
    private SunRotation sunRotation;

    private void Awake()
    {
        player = GameObject.Find("Player");
        sunRotation = GameObject.Find("Sun").GetComponent<SunRotation>();
    }

    private void Update()
    {
        if (sunRotation.IsNight)
        {
            ShootRay();
        }
    }

    private void ShootRay()
    {
        RaycastHit paperHit;

        Physics.Raycast(transform.position, player.transform.position + new Vector3(0f, 1f, 0f) - transform.position, out paperHit, rayDistance, heldLayer);

        if (paperHit.collider && paperHit.collider.CompareTag("Paper"))
        {
            Debug.Log("변경 텍스쳐");
        }
        else if (!paperHit.collider)
        {
            Debug.Log("원래 텍스쳐");
        }
    }
}
