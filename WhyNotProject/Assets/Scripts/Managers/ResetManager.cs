using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetManager : MonoBehaviour
{
	[SerializeField] private List<TextMeshProUGUI> creditTexts;
	[SerializeField] private List<Image> creditImages;
	[SerializeField] private GameObject lockedCursor;
	[SerializeField] private CinemachineVirtualCamera creditCamera;
	[SerializeField] private PlayerController playerController;
	private bool canGoMain;

    private void Update()
    {
        if (canGoMain && Input.anyKey)
		{
            OptionUI.instance.onCredit = false;

            SceneManager.LoadScene("StartScene");
		}
    }

    private void OnTriggerEnter(Collider other)
	{
		OptionUI.instance.onCredit = true;
		playerController.enabled = false;

		lockedCursor.SetActive(false);

        creditCamera.Priority = 11;

		Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(3.5f)
            .Append(creditTexts[0].DOFade(1, 2))
            .Join(creditImages[0].DOFade(1, 2))
            .Append(creditTexts[1].DOFade(1, 2))
            .Join(creditTexts[2].DOFade(1, 2))
            .Join(creditTexts[3].DOFade(1, 2))
            .Join(creditTexts[4].DOFade(1, 2))
            .Join(creditTexts[5].DOFade(1, 2))
            .Join(creditTexts[6].DOFade(1, 2))
            .AppendInterval(1f)
            .Append(creditTexts[0].DOFade(0, 2))
            .Join(creditImages[0].DOFade(0, 2))
            .Join(creditTexts[1].DOFade(0, 2))
            .Join(creditTexts[2].DOFade(0, 2))
            .Join(creditTexts[3].DOFade(0, 2))
            .Join(creditTexts[4].DOFade(0, 2))
            .Join(creditTexts[5].DOFade(0, 2))
            .Join(creditTexts[6].DOFade(0, 2))
            .AppendInterval(1f)
            .Append(creditTexts[7].DOFade(1, 2))
            .Append(creditImages[1].DOFade(1, 2))
            .AppendCallback(() =>
            {
                float playTime = OptionUI.instance.playTime;

                creditTexts[8].text = $"{Mathf.FloorToInt(playTime / 3600f)}시간 {Mathf.FloorToInt(playTime % 3600f / 60f)}분 {Mathf.FloorToInt(playTime % 3600f % 60f)}초 만에 트라우마 극복\n(인게임 시간 {Mathf.FloorToInt(SunRotation.passedDay)}일)";
            })
            .Append(creditTexts[8].DOFade(1, 2))
            .AppendCallback(() =>
            {
                canGoMain = true;

                StartCoroutine("BlinkText");
            });
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            creditTexts[9].text = "";

            yield return new WaitForSeconds(.5f);

            creditTexts[9].text = "Press a key to Main";

            yield return new WaitForSeconds(.5f);
        }
    }
}
