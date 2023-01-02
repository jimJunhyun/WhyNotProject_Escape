using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<string> flagNames;
    public Dictionary<string, bool> flags = new Dictionary<string, bool>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (string flagName in flagNames)
        {
            flags.Add(flagName, false);
        }

        CCManager.instance.CurrentCondition = "Start";
    }

    public void InputCoin()
    {
        if (flags.ContainsKey(flagNames[0]))
        {
            if (!flags[flagNames[0]])
            {
                CCManager.instance.CurrentCondition = flagNames[0];
                flags[flagNames[0]] = true;
            }
        }
    }

    public void FindPaper()
    {
        if (flags.ContainsKey(flagNames[1]))
        {
            if (!flags[flagNames[1]])
            {
                CCManager.instance.CurrentCondition = flagNames[1];
                flags[flagNames[1]] = true;
            }
        }
    }

    public void HoldPaper()
    {
        if (flags.ContainsKey(flagNames[2]))
        {
            if (!flags[flagNames[2]])
            {
                CCManager.instance.CurrentCondition = flagNames[2];
                flags[flagNames[2]] = true;
            }
        }
    }

    public void EnterCode()
    {
        if (flags.ContainsKey(flagNames[3]))
        {
            if (!flags[flagNames[3]])
            {
                CCManager.instance.CurrentCondition = flagNames[3];
                flags[flagNames[3]] = true;
            }
        }
    }

    public void FindLever()
    {
        if (flags.ContainsKey(flagNames[4]))
        {
            if (!flags[flagNames[4]])
            {
                CCManager.instance.CurrentCondition = flagNames[4];
                flags[flagNames[4]] = true;
            }
        }
    }

    public void ClearLever()
    {
        if (flags.ContainsKey(flagNames[5]))
        {
            if (!flags[flagNames[5]])
            {
                CCManager.instance.CurrentCondition = flagNames[5];
                flags[flagNames[5]] = true;
            }
        }
    }

    public void OpenCoinBox()
    {
        if (flags.ContainsKey(flagNames[6]))
        {
            if (!flags[flagNames[6]])
            {
                CCManager.instance.CurrentCondition = flagNames[6];
                flags[flagNames[6]] = true;
            }
        }
    }

    public void PutCoinMailBox()
    {
        if (flags.ContainsKey(flagNames[7]))
        {
            if (!flags[flagNames[7]])
            {
                CCManager.instance.CurrentCondition = flagNames[7];
                flags[flagNames[7]] = true;
            }
        }
    }

    public void HoldMail()
    {
        if (flags.ContainsKey(flagNames[8]))
        {
            if (!flags[flagNames[8]])
            {
                CCManager.instance.CurrentCondition = flagNames[8];
                flags[flagNames[8]] = true;
            }
        }
    }
    
    public void End()
    {
        if (flags.ContainsKey(flagNames[9]))
        {
            if (!flags[flagNames[9]])
            {
                CCManager.instance.CurrentCondition = flagNames[9];
                flags[flagNames[9]] = true;
            }
        }
    }
}
