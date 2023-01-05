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
    public float blankOutputTime = 1.5f;
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
    [HideInInspector] public List<string> outputCaptions = new List<string>();
    private Dictionary<string, ClosedCaption> ccDictionary = new Dictionary<string, ClosedCaption>();
    private Coroutine ccCoroutine;
    private ClosedCaptionList ccList;
    private string currentCondition;
    public string CurrentCondition
    {
        get { return currentCondition; }
        set
        {
            currentCondition = value;

            if (ccCoroutine != null)
            {
                StopCoroutine(ccCoroutine);
            }

            ccCoroutine = StartCoroutine(CCOutputDelay());
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
        ccList = JsonUtility.FromJson<ClosedCaptionList>(ccJSONFile.text);

        foreach (ClosedCaption cc in ccList.captions)
        {
            ccDictionary.Add(cc.conditionNumber, cc);
        }
    }

    private IEnumerator CCOutputDelay()
    {
        int index = 1;

        if (!ccDictionary.ContainsKey(currentCondition))
        {
            if (ccDictionary.ContainsKey($"{currentCondition}_1_1"))
            {
                yield return new WaitForSeconds(ccDictionary[$"{currentCondition}_1_1"].blankOutputTime);

                for (; ; index++)
                {
                    if (ccDictionary.ContainsKey($"{currentCondition}_1_{index}"))
                    {
                        ccText.text = ccDictionary[$"{currentCondition}_1_{index}"].captionText;

                        outputCaptions.Add(ccText.text);

                        yield return new WaitForSeconds(ccDictionary[$"{currentCondition}_1_{index}"].outputTime);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (ccDictionary.ContainsKey($"{currentCondition}_2_1"))
            {
                yield return new WaitForSeconds(ccDictionary[$"{currentCondition}_2_1"].blankOutputTime);

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

                outputCaptions.Add(ccText.text);

                yield return new WaitForSeconds(ccDictionary[$"{currentCondition}_2_{UnityEngine.Random.Range(1, index)}"].outputTime);
            }

            ccText.text = null;
        }
        else
        {
            yield return new WaitForSeconds(ccDictionary[currentCondition].blankOutputTime);

            ccText.text = ccDictionary[currentCondition].captionText;

            outputCaptions.Add(ccText.text);

            yield return new WaitForSeconds(ccDictionary[currentCondition].outputTime);

            ccText.text = null;
        }

        ccCoroutine = null;

        StopCoroutine("CCOutputDelay");
    }
}
