using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            CCManager.instance.CurrentCondition = "Start";
        }
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

    public void HoldPen()
    {
        int index = flagNames.IndexOf("HoldPen");

        ConditionChange(index);
    }

    public void SolvePaper()
    {
        int index = flagNames.IndexOf("SolvePaper");

        ConditionChange(index);
    }

    public void FindLock()
    {
        int index = flagNames.IndexOf("FindLock");

        ConditionChange(index);
    }

    public void FindPower()
    {
        int index = flagNames.IndexOf("FindPower");

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

    public void PutCoinModule()
    {
        int index = flagNames.IndexOf("PutCoinModule");

        ConditionChange(index);
    }

    public void CallFail()
    {
        if (!flags["CallFail1"])
        {
            CCManager.instance.CurrentCondition = "CallFail1";
            flags["CallFail1"] = true;
        }
        else if (!flags["CallFail2"])
        {
            CCManager.instance.CurrentCondition = "CallFail2";
            flags["CallFail2"] = true;
        }
        else if (!flags["CallFail3"])
        {
            CCManager.instance.CurrentCondition = "CallFail3";
            flags["CallFail3"] = true;
        }
        else if (!flags["CallFail4"])
        {
            CCManager.instance.CurrentCondition = "CallFail4";
            flags["CallFail4"] = true;
        }
        else if (!flags["CallFail5"])
        {
            CCManager.instance.CurrentCondition = "CallFail5";
            flags["CallFail"] = true;
        }
    }

    public void LastCoinRemain()
    {
        int index = flagNames.IndexOf("LastCoinRemain");

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

    public void HappyEnding()
    {
        int index = flagNames.IndexOf("HappyEnding");

        ConditionChange(index);
    }

    public void HappyEndingCredit()
    {
        int index = flagNames.IndexOf("HappyEndingCredit");

        ConditionChange(index);
    }

    public void BadEnding()
    {
        int index = flagNames.IndexOf("BadEnding");

        ConditionChange(index);
    }

    public void BadEndingCredit()
    {
        int index = flagNames.IndexOf("BadEndingCredit");

        ConditionChange(index);
    }

    private void ConditionSkip(int index)
    {
        for (int i = 1; i < index; i++)
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
