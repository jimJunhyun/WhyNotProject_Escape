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

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "StartScene")
        {
            ccText.text = OptionUI.instance.optionOpened ? "자막은 이렇게 표시됩니다." : "";
        }
    }

    private IEnumerator CCOutputDelay()
    {
        

        int index = 1;

        yield return new WaitForSeconds(1.5f);

        if (!ccDictionary.ContainsKey(currentCondition))
        {
            if (ccDictionary.ContainsKey($"{currentCondition}_1_1"))
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
            else if (ccDictionary.ContainsKey($"{currentCondition}_2_1"))
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

            ccText.text = null;
        }
        else
        {
            ccText.text = ccDictionary[currentCondition].captionText;

            yield return new WaitForSecondsRealtime(ccDictionary[currentCondition].outputTime);

            ccText.text = null;
        }

        ccCoroutine = null;
        StopCoroutine("CCOutputDelay");
    }
}
