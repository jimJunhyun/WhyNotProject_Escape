using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressManager : MonoBehaviour
{

    public string Key;
    string currentKey;

    public UnityEvent OnMatched;

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
            Debug.Log("!!");
            OnMatched.Invoke();
            currentKey = "";
		}
    }

    public void AddKey(string Key)
	{
        currentKey += Key;
	}
}
