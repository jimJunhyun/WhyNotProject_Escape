using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
	public ManagerScene scener;

	private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

	public void Restart()
	{
		scener.Change("PlayScene");
	}

	public void Home()
	{
        scener.Change("StartScene");
    }
}
