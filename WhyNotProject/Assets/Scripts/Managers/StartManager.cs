using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    private OptionUI optionUI;

    private void Start()
    {
        optionUI = GameObject.Find("OptionPanel").GetComponent<OptionUI>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.O) && optionUI.optionOpened == false)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
}
