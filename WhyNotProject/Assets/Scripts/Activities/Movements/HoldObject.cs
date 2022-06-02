using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    public float HoldZ;
    Camera cam;
    public static Vector3 HoldPos = new Vector3();
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        HoldPos = GetWorldPositionOnPlane(cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f)), HoldZ);
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(HoldPos);
        HoldPos = GetWorldPositionOnPlane(cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f)), HoldZ); //가운데에 Z거리만큼
    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
	{
		Ray ray = cam.ScreenPointToRay(screenPosition);
		return ray.GetPoint(z);
	}
}
