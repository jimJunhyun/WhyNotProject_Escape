using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

    public void FirstLightOn()
    {
        int index = flagNames.IndexOf("FirstLightOn");

        ConditionChange(index);
    }

    public void InputCoin()
    {
        int index = flagNames.IndexOf("InputCoin");

        ConditionChange(index);
    }

    public void FindPaper()
    {
        int index = flagNames.IndexOf("FindPaper");

        ConditionChange(index);
    }

    public void HoldPaper()
    {
        int index = flagNames.IndexOf("HoldPaper");

        ConditionChange(index);
    }

    public void EnterCode()
    {
        int index = flagNames.IndexOf("EnterCode");

        ConditionSkip(index);
        ConditionChange(index);
    }

    public void FindLever()
    {
        int index = flagNames.IndexOf("FindLever");

        ConditionChange(index);
    }

    public void ClearLever()
    {
        int index = flagNames.IndexOf("ClearLever");

        ConditionChange(index);
    }

    public void OpenCoinBox()
    {
        int index = flagNames.IndexOf("OpenCoinBox");

        ConditionChange(index);
    }

    public void PutCoinMailBox()
    {
        int index = flagNames.IndexOf("PutCoinMailBox");

        ConditionChange(index);
    }

    public void HoldMail()
    {
        int index = flagNames.IndexOf("HoldMail");

        ConditionChange(index);
    }
    
    public void End()
    {
        int index = flagNames.IndexOf("End");

        ConditionSkip(index);
        ConditionChange(index);
    }

    private void ConditionSkip(int index)
    {
        for (int i = 0; i < index; i++)
        {
            if (!flags[flagNames[i]])
            {
                flags[flagNames[i]] = true;
            }
        }
    }

    private void ConditionChange(int index)
    {
        if (flags.ContainsKey(flagNames[index]))
        {
            if (!flags[flagNames[index]])
            {
                CCManager.instance.CurrentCondition = flagNames[index];
                flags[flagNames[index]] = true;
            }
        }
    }
}
