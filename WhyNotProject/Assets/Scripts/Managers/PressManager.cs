using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressManager : MonoBehaviour
{

    public string Key;
    public string Checker = null;
    string currentKey;
    string prevKey;

    public UnityEvent OnMatched;

    // Start is called before the first frame update
    void Awake()
    {
        currentKey = "";
        prevKey = currentKey;
    }

    // Update is called once per frame
    void Update()
    {
        if(Checker == "" && prevKey != currentKey)
		{
            CheckKey();
		}
    }

    public void AddKey(string Key)
	{
        if(Checker != null && Key == Checker)
		{
            CheckKey();
            
		}
		else
		{
            currentKey += Key;
        }
        
	}

    void CheckKey()
	{
        prevKey = currentKey;
        if (currentKey == Key)
        {
            OnMatched.Invoke();
            currentKey = "";
        }
		else
		{
            currentKey = "";
		}
        
    }
}
