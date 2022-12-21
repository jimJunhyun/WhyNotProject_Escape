using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class StartText : MonoBehaviour
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

            flashingText.text = (SceneManager.GetActiveScene().buildIndex == 0) ? "Press a key to Start" : "Press H key to Home";

            yield return new WaitForSeconds(.5f);
        }

    }

}