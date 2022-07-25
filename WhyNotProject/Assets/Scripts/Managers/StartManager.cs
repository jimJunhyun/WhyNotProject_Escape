using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.O) && OptionUI.Instance.optionOpened == false)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
}
