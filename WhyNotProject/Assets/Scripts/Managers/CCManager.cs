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
        string[] conditionSplit = currentCondition.Split('_');
        int index = 1;

        if (conditionSplit[1] != null)
        {
            if (conditionSplit[1] == "1")
            {
                for (; ; index++)
                {
                    if (ccDictionary.ContainsKey($"{currentCondition}_1_{index}"))
                    {
                        ccText.text = ccDictionary[$"{currentCondition}_1_{index}"].captionText;

                        yield return new WaitForSecondsRealtime(ccDictionary[$"{currentCondition}_1_{index}"].outputTime);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (conditionSplit[1] == "2")
            {
                for (; ; index++)
                {
                    if (ccDictionary.ContainsKey($"{currentCondition}_2_{index}"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                ccText.text = ccDictionary[$"{currentCondition}_2_{UnityEngine.Random.Range(1, index)}"].captionText;

                yield return new WaitForSecondsRealtime(ccDictionary[$"{currentCondition}_2_{UnityEngine.Random.Range(1, index)}"].outputTime);
            }
        }
        else
        {
            if (ccDictionary.ContainsKey($"{currentCondition}"))
            {
                ccText.text = ccDictionary[currentCondition].captionText;

                yield return new WaitForSecondsRealtime(ccDictionary[currentCondition].outputTime);
            }
        }

        ccText.text = null;

        yield return null;

        StopCoroutine("CCOutputDelay");
    }
}
