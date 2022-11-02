using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClosedCaption
{
    public string conditionNumber = "";
    public string captionText = "";
    public float outputTime = 3f;
}

public class ClosedCaptionData
{
    public List<ClosedCaption> captions;
}

public class CCManager : MonoBehaviour
{
    [SerializeField] private TextAsset ccJSONFile;
    private Dictionary<string, ClosedCaption> captionDictionary;

    private void Start()
    {
        ParseJSON();
    }

    private void ParseJSON()
    {
        ClosedCaptionData caption = JsonUtility.FromJson<ClosedCaptionData>(ccJSONFile.text);

        Debug.Log(caption.captions[0].captionText);
    }
}
