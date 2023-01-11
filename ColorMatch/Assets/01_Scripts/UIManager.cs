using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public TextMeshProUGUI overScoreTxt;
    public TextMeshProUGUI overBestScoreTxt;

    public GameObject overCanvas;
    public GameObject escMenu;
    public Animator overAni;

    private bool isEsc = false;

    public AudioManager audioManager;

    public Toggle muteBtn;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.CheckMute(muteBtn);
        scoreTxt.text = GameManager.instance.score.ToString();
    }

    private void Update()
    {
        scoreTxt.text = GameManager.instance.score.ToString() + " 점";
        overScoreTxt.text = $"점수 : {GameManager.instance.score.ToString()}" ;
        overBestScoreTxt.text = $"최고 점수 : {GameManager.instance.bestScore.ToString()}";

        if (Input.GetKeyDown(KeyCode.F))
        {
            UpSlide();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEsc)
            {
                Resume();
            }
            else
            {
                EscMenu();
            }
        }
    }

    public void MuteUI(bool isMute)
    {
        audioManager.Mute(isMute);
    }

    public void EscMenu()
    {
        Sequence seq = DOTween.Sequence();
            seq.SetUpdate(true);
            seq.AppendCallback(() => Time.timeScale = 0);
            seq.AppendCallback(() => isEsc = true);
            seq.Append(escMenu.transform.DOLocalMove(new Vector3(0, 0, 90), 1));
    }

    public void Resume()
    {
        Sequence seq = DOTween.Sequence();
        seq.SetUpdate(true);
        seq.AppendCallback(() => isEsc = false);
        seq.AppendCallback(() => escMenu.transform.DOLocalMove(new Vector3(0, 400, 90), 1));
        Time.timeScale = 1;
    }


    public void UpSlide()
    {
        overCanvas.transform.DOLocalMove(new Vector3(0, 0, 90), 2);
        StartCoroutine(Wait(2));
    }
    
    public void QuitGame()
    {
        Debug.Log("빠이");
        Application.Quit();
    }

    public void RestartGame(int n)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(n);
    }

    public void GoTitle(int n)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(n);
    }

    IEnumerator Wait(float s)
    {
        yield return new WaitForSeconds(s);
        overAni.SetTrigger("Broken");
    }
}
