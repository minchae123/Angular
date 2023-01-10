using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public TextMeshProUGUI overScoreTxt;
    public TextMeshProUGUI overBestScoreTxt;

    public GameObject overCanvas;

    private void Start()
    {
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
    }

    public void UpSlide()
    {
        overCanvas.transform.DOLocalMove(new Vector3(0, 0, 90), 2);
    }
    
    public void QuitGame()
    {
        Debug.Log("빠이");
        Application.Quit();
    }

    public void RestartGame(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void GoTitle(int n)
    {
        SceneManager.LoadScene(n);
    }


}
