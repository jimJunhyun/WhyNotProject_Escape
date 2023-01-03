using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
	private Animator animator;

	public bool isActive = false;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void StartGame()
	{
		if (isActive) return;
		isActive = true;
		animator.SetTrigger("Start");
		StartCoroutine(StartDelay());
	}

	IEnumerator StartDelay()
	{
		yield return new WaitForSeconds(3f);
		int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(sceneBuildIndex + 1);
	}
}
