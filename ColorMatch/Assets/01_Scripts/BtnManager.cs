using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using DG.Tweening;


public class BtnManager : MonoBehaviour
{
    // 패널
    public GameObject tutPanel;
    public GameObject TitlePanel;

    // 버튼
    public GameObject StartBtn;
    public GameObject tutorialBtn;
    public GameObject tutOutBtn;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public GameObject ExitBtn;
    public Toggle muteBtn;

    private Button ExitBtn_B;
    private Button tutBtn_B;
    private Button StartBtn_B;

    private AudioSource audios;
    public AudioClip ClickSound;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.CheckMute(muteBtn);

        ExitBtn_B = GameObject.Find("ExitBtn").GetComponent<Button>();
        tutBtn_B = GameObject.Find("TutorialBtn").GetComponent<Button>();
        StartBtn_B = GameObject.Find("StartBtn").GetComponent<Button>();

        if (SoundOffBtn != null)
        {
            SoundOffBtn.SetActive(false);
        }

        audios = gameObject.AddComponent<AudioSource>();
        audios.clip = ClickSound;
        audios.loop = false;
    }

    public void MuteUI(bool isMute)
    {
        audioManager.Mute(isMute);
    }

    public void OnClickStart() // 스타트 클릭시
    {
        SceneManager.LoadScene("PlaySquare");
    }

    public void OnClickTut() // 튜토리얼 버튼 클릭시
    {
        audios.Play();

        tutPanel.transform.DOLocalMove(new Vector3(0, 0, 0), 0.8f);

        StartBtn_B.interactable = false;
        ExitBtn_B.interactable = false;
        tutBtn_B.interactable = false;
    }

    public void OnClickTutOut() // 튜토리얼 X 버튼 클릭시
    {
        audios.Play();
        
        tutPanel.transform.DOLocalMove(new Vector3(0, -2000, 0), 0.8f);

        StartBtn_B.interactable = true;
        ExitBtn_B.interactable = true;
        tutBtn_B.interactable = true;
    }
    

    public void OnClickExit()
    {
        Debug.Log("나가기");
        Application.Quit();
    }
}
