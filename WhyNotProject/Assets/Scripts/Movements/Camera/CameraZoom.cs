using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private int normalFOV = 60;
    [SerializeField] private int zoomedFOV = 20;
    [Range(0, 1)]
    [SerializeField] private float lerpSpeed = 1.0f;
    [SerializeField] private KeyCode zoomKeyCode = KeyCode.Z;

    private bool isZoomed = false;
    private Camera camera;

	private void Start()
	{
		camera = GetComponent<Camera>();
	}

	private void Update()
    {
        Zoom();
        isZoomed = Input.GetKeyDown(zoomKeyCode) ? !isZoomed : isZoomed;
    }

    private void Zoom()
    {
        if (isZoomed == false)
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, normalFOV, lerpSpeed);
        }
        else
        {
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomedFOV, lerpSpeed);
        }
    }
}
