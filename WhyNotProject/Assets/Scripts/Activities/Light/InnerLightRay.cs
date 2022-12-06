using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLightRay : MonoBehaviour
{
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

        Physics.Raycast(transform.position, player.transform.position - transform.position, out paperHit, rayDistance, 2);

        if (paperHit.collider)
        {
            Debug.Log("변경 텍스쳐");
        }
        else if (!paperHit.collider)
        {
            Debug.Log("원래 텍스쳐");
        }
    }
}
