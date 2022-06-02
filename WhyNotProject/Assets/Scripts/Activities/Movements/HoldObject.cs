using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    Camera cam;
    public static Vector3 HoldPos = new Vector3();
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        HoldPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetWorldPositionOnPlane(Input.mousePosition, 10));
		Debug.Log(HoldPos);
        HoldPos = GetWorldPositionOnPlane(cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f)), transform.position.z);
    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
	{
		Ray ray = cam.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
}
