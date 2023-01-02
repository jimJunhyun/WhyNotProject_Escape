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
    public Vector3 throwDirection;
    public float holdLimit;
    Camera cam;
    [HideInInspector]
    public Vector3 HoldPos = new Vector3();
    [HideInInspector]
    public Holdable currentHolding;
    
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
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
	{
		Ray ray = cam.ScreenPointToRay(screenPosition);
        throwDirection = ray.direction.normalized;
        //Debug.DrawRay(ray.origin, ray.direction);
        RaycastHit info;
        if(Physics.Raycast(ray, out info, z, ignoreLayer))
		{
            if(currentHolding != null)
                z = info.distance - currentHolding.bufferArea;
            else
                z = info.distance;
            
            //Debug.Log(info.collider);
        }
		return ray.GetPoint(z);
	}
    public bool MouseCursorDetect(out RaycastHit hit)
	{
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit, holdLimit);
        Debug.DrawLine(ray.origin, hit.point, Color.cyan);

        if (hit.collider)
        {
            switch (hit.collider.name)
            {
                case "PostIt":
                    if (currentHolding == null)
                    {
                        GameManager.instance.FindPaper();
                    }
                    else
                    {
                        GameManager.instance.HoldPaper();
                    }

                    break;
                case "RefinedCoin (1)":
                case "RefinedCoin (2)":
                case "RefinedCoin (3)":
                case "RefinedCoin (4)":
                case "RefinedCoin (5)":
                    GameManager.instance.OpenCoinBox();

                    break;
                case "Letter":
                    if (currentHolding != null)
                    {
                        GameManager.instance.HoldMail();
                    }

                    break;
                default:
                    break;
            }
        }

        return isHit;
	}
}
