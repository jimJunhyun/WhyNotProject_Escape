using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressManager : MonoBehaviour
{

    public string Key;
    public string Checker = null;
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
        if(Checker == null)
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
        if (currentKey == Key)
        {
            Debug.Log("!!");
            OnMatched.Invoke();
            currentKey = "";
        }
		else
		{
            Debug.Log("??");
            currentKey = "";
		}
    }
}
