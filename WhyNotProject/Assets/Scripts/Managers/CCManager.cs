using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class ClosedCaption
{
    public string conditionNumber = "";
    public string captionText = "";
    public float outputTime = 3f;
}

public class ClosedCaptionList
{
    public List<ClosedCaption> captions;
}

public class CCManager : MonoBehaviour
{
    public static CCManager instance;

    [SerializeField] private TextMeshProUGUI ccText;
    [SerializeField] private TextAsset ccJSONFile;
    private ClosedCaptionList ccList;
    private Dictionary<string, ClosedCaption> ccDictionary = new Dictionary<string, ClosedCaption>();
    private string currentCondition;
    public string CurrentCondition
    {
        get { return currentCondition; }
        set
        {
            currentCondition = value;

            StartCoroutine("CCOutputDelay");
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ccText.text = "";
        ccList = JsonUtility.FromJson<ClosedCaptionList>(ccJSONFile.text);

        foreach (ClosedCaption cc in ccList.captions)
        {
            ccDictionary.Add(cc.conditionNumber, cc);
        }
    }

    private IEnumerator CCOutputDelay()
    {
        for (int i = 1; ; i++)
        {
            if (ccDictionary.ContainsKey($"{currentCondition}_{i}"))
            {
                ccText.text = ccDictionary[$"{currentCondition}_{i}"].captionText;

                yield return new WaitForSecondsRealtime(ccDictionary[$"{currentCondition}_{i}"].outputTime);
            }
            else
            {
                ccText.text = null;

                break;
            }
        }

        yield return null;

        StopCoroutine("CCOutputDelay");
    }
}
