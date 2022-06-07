using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 들 수 있는 물체를 컨트롤하는 스크립트이다.
/// 어디에 붙어있는 상관없는 매니저.
/// </summary>
public class HoldManager : MonoBehaviour
{
    public static HoldManager Instance;
    public float HoldZ;
    public LayerMask ignoreLayer;
    public float throwPower;
    Camera cam;
    [HideInInspector]
    public Vector3 HoldPos = new Vector3();
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        ignoreLayer = ~ignoreLayer;
        cam = Camera.main;
        HoldPos = GetWorldPositionOnPlane(cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f)), HoldZ);
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(HoldPos);
        HoldPos = GetWorldPositionOnPlane(cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f)), HoldZ); //가운데에 Z거리만큼
    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z, float objRadius = 0.4f)
	{
		Ray ray = cam.ScreenPointToRay(screenPosition);
        //Debug.DrawRay(ray.origin, ray.direction);
        RaycastHit info;
        if(Physics.Raycast(ray, out info, z, ignoreLayer))
		{
            z = info.distance - objRadius;
            //Debug.Log(info.collider);
        }
		return ray.GetPoint(z);
	}
}
