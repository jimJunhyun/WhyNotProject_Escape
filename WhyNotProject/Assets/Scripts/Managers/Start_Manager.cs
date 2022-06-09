using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Manager : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
}
