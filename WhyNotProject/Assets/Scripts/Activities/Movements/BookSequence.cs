using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSequence : MonoBehaviour
{
    public Mesh opened;
    public Mesh closed;

    public List<Material> openMats;
    public List<Material> closedMats;

    public BoxCollider openCol;
    public BoxCollider closeCol;
   

    bool isOpened = false;
    MeshRenderer rend;
    MeshFilter filt;

	private void Awake()
	{
        filt = GetComponent<MeshFilter>();
		rend = GetComponent<MeshRenderer>();
	}

	public void NextPage()
	{
        if(isOpened)
		{
            isOpened = false;
            rend.materials = closedMats.ToArray();
            filt.mesh = closed;
            closeCol.enabled = true;
            openCol.enabled = false;
		}
		else
		{
            isOpened = true;
            rend.materials = openMats.ToArray();
            filt.mesh = opened;
            closeCol.enabled = false;
            openCol.enabled = true;
		}
	}
}
