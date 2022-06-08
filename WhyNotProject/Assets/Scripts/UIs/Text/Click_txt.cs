using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Click_txt : MonoBehaviour
{

    TextMeshProUGUI flashingText;
    void Start()
    {
        flashingText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "Press a key to Start";
            yield return new WaitForSeconds(.5f);

        }

    }

}