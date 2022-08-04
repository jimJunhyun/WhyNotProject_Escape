using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressManager : MonoBehaviour
{

    public string Key;
    string currentKey;

    // Start is called before the first frame update
    void Awake()
    {
        currentKey = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(currentKey == Key)
		{

		}
    }

    public void AddKey(string Key)
	{
        currentKey += Key;
	}
}
