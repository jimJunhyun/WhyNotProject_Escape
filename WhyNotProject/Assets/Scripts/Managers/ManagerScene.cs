using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{

	public void DelayChange(float time, string name)
	{
		StartCoroutine(Delay(time, name));
	}

	IEnumerator Delay(float time, string name)
	{
		yield return new WaitForSeconds(time);
		Change(name);
	}

	public void Change(string name)
	{
		SceneManager.LoadScene(name);
	}
}
