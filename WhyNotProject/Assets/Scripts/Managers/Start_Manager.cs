using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Manager : MonoBehaviour
{
    private OptionUI optionUI;

    private void Start()
    {
        optionUI = GameObject.Find("OptionPanel").GetComponent<OptionUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionUI.optionOpened == false)
        {
            optionUI.optionOpened = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && optionUI.optionOpened == true)
        {
            optionUI.optionOpened = false;
        }
        else if (!Input.GetKeyDown(KeyCode.Escape) && optionUI.optionOpened == false)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
}
