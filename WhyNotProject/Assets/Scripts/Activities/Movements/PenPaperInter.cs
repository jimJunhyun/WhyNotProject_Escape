using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PenPaperInter : MonoBehaviour
{
    public Holdable pen;

    public Texture HintPaper;

    public UnityEvent OnMatched;

    Renderer render;

    // Start is called before the first frame update
    void Awake()
    {
        render = GetComponent<MeshRenderer>();
    }

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.GetComponent<Holdable>() == pen)
		{
            OnMatched.Invoke();
		}
	}

	public void Write()
	{
        Debug.Log("!!!");
        render.material.SetTexture("_MainTex", HintPaper);
	}
}
