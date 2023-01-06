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
    [SerializeField] private List<Light> lamps;
	[SerializeField] private List<TextMeshProUGUI> creditTexts;
	[SerializeField] private List<Image> creditImages;
	[SerializeField] private GameObject lockedCursor;
    [SerializeField] private Material bgMaterial;
    [SerializeField] private Material lampMaterial;
    [SerializeField] private CinemachineVirtualCamera mainCamera;
	[SerializeField] private CinemachineVirtualCamera creditCamera;
	[SerializeField] private PlayerController playerController;
    private bool canGoMain;

    private void Start()
    {
        bgMaterial.color = OptionUI.instance.isHappyEnd ? Color.white : Color.black;
        lampMaterial.color = OptionUI.instance.isHappyEnd ? Color.white : Color.black;

        lampMaterial.SetColor("_EmissionColor", OptionUI.instance.isHappyEnd ? Color.white : new Color(128f / 255f, 0f, 0f, 1f));
        
        Camera.main.backgroundColor = OptionUI.instance.isHappyEnd ? Color.white : Color.black;

        for (int i = 0; i < lamps.Count; i++)
        {
            lamps[i].color = OptionUI.instance.isHappyEnd ? Color.white : Color.red;
        }

        mainCamera.m_Lens.FieldOfView = 50f;
        playerController.enabled = false;

        lockedCursor.SetActive(false);

        if (OptionUI.instance.isHappyEnd) GameManager.instance.HappyEnding();
        else GameManager.instance.BadEnding();

        Sequence ending = DOTween.Sequence();

        ending.AppendInterval(22.5f)
            .AppendCallback(() =>
            {
                mainCamera.m_Lens.FieldOfView = 60f;
                playerController.enabled = true;

                lockedCursor.SetActive(true);
            });
    }

    private void Update()
    {
        if (canGoMain && Input.anyKey)
		{
            OptionUI.instance.onCredit = false;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("StartScene");
		}
    }

    private void OnTriggerEnter(Collider other)
	{
		OptionUI.instance.onCredit = true;
		playerController.enabled = false;

		lockedCursor.SetActive(false);

        creditCamera.Priority = 11;

        if (OptionUI.instance.isHappyEnd) GameManager.instance.HappyEndingCredit();
        else GameManager.instance.BadEndingCredit();

        Sequence endingCredit = DOTween.Sequence();

        endingCredit.AppendInterval(4f)
            .Append(creditTexts[0].DOFade(1, 2))
            .Append(creditImages[0].DOFade(1, 4))
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

                creditTexts[8].text = OptionUI.instance.isHappyEnd ?
                $"{Mathf.FloorToInt(playTime / 3600f)}시간 {Mathf.FloorToInt(playTime % 3600f / 60f)}분 {Mathf.FloorToInt(playTime % 3600f % 60f)}초 만에 트라우마 극복\n(인게임 시간 {Mathf.FloorToInt(SunRotation.passedDay)}일)" :
                $"{Mathf.FloorToInt(playTime / 3600f)}시간 {Mathf.FloorToInt(playTime % 3600f / 60f)}분 {Mathf.FloorToInt(playTime % 3600f % 60f)}초 간 시도했으나 트라우마 극복 실패\n(인게임 시간 {Mathf.FloorToInt(SunRotation.passedDay)}일)";
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
