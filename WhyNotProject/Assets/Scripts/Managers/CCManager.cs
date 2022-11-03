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

public class CCManager : MonoBehaviour
{
    public static CCManager instance;

    [SerializeField] private TextMeshProUGUI ccText;
    [SerializeField] private TextAsset ccJSONFile;
    private Dictionary<string, ClosedCaption> captions;
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
        captions = JsonUtility.FromJson<Dictionary<string, ClosedCaption>>(ccJSONFile.text);
    }

    private void Update()
    {
        OnClickTest();
    }

    private IEnumerator CCOutputDelay()
    {
        for (int i = 0; ; i++)
        {
            if (captions[$"{currentCondition}_{i}"] != null)
            {
                ccText.text = captions[$"{currentCondition}_{i}"].captionText;

                yield return new WaitForSecondsRealtime(captions[$"{currentCondition}_{i}"].outputTime);
            }
            else
            {
                break;
            }
        }

        StopCoroutine("CCOutputDelay");
    }

    public void OnClickTest()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CurrentCondition = "Test";
        }
    }
}
