using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CCManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ccText;
    private Coroutine ccCoroutine;
    private int ccCount;
    public int CCCount
    {
        get { return ccCount; }
        set
        {
            ccCount = value;
            ccCoroutine = StartCoroutine(CCPrint(ccCount));
        }
    }

    private void Awake()
    {
        ccCount = 0;
    }

    private IEnumerator CCPrint(int ccCount)
    {
        List<Dictionary<string, object>> ccList = CSVReader.Read("���⿡ .csv ���� �̸�");

        for (int i = 0; i < ccList.Count; i++)
        {
            ccText.text = ccList[i].ToString();

            yield return new WaitForSeconds(0 /*���⿡ �������� ��� �� �ð�*/);
        }

        StopCoroutine(ccCoroutine);
    }
}
