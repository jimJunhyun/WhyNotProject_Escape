using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerLightRay : MonoBehaviour
{
    [SerializeField] private LayerMask heldLayer;
    [SerializeField] private Material paperMaterial;
    [SerializeField] private float rayDistance;
    private GameObject player;
    private SunRotation sunRotation;

    private void Awake()
    {
        player = GameObject.Find("Player");
        sunRotation = GameObject.Find("Sun").GetComponent<SunRotation>();
        paperMaterial.color = Color.white;
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
            paperMaterial.color = new Color(paperMaterial.color.r, paperMaterial.color.g, paperMaterial.color.b, 235f / 255f);
        }
        else if (!paperHit.collider)
        {
            paperMaterial.color = new Color(paperMaterial.color.r, paperMaterial.color.g, paperMaterial.color.b, 1f);
        }
    }
}
