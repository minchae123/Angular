using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using DG.Tweening;

public class BtnManager : MonoBehaviour
{
    // �г�
    public GameObject RectPanel;
    public GameObject HexPanel;
    public GameObject tutPanel;
    public GameObject TitlePanel;

    // ��ư
    public GameObject StartBtn;
    public GameObject tutorialBtn;
    public GameObject tutOutBtn;
    public GameObject SoundOnBtn;
    public GameObject SoundOffBtn;
    public GameObject ExitBtn;
    public GameObject GobackBtn;
    public Toggle muteBtn;


    private Button ExitBtn_B;
    private Button tutBtn_B;

    private AudioSource audio;
    public AudioClip ClickSound;

    public AudioManager audioManager;

    bool OnOff = true;


    private void Awake()
    {

        audioManager = FindObjectOfType<AudioManager>();
        audioManager.CheckMute(muteBtn);
        ExitBtn_B = GameObject.Find("ExitBtn").GetComponent<Button>();
        tutBtn_B = GameObject.Find("TutorialBtn").GetComponent<Button>();

        if(tutPanel!=null)
        {
            tutPanel.SetActive(false);
        }
        if(tutOutBtn!=null)
        {
            tutOutBtn.SetActive(false);
        }
        if (SoundOffBtn != null)
        {
            SoundOffBtn.SetActive(false);
        }

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.ClickSound;
        this.audio.loop = false;
    }

    public void MuteUI(bool isMute)
    {
        audioManager.Mute(isMute);
    }

    public void OnClickStart() // ��ŸƮ Ŭ����
    {
        this.audio.Play();

        // �簢�� ����
        RectPanel.transform.DOLocalMove(new Vector3(-250, 0, 0), 0.8f);
        RectPanel.SetActive(true);

        // ������ ����
        HexPanel.SetActive(true);
        HexPanel.transform.DOLocalMove(new Vector3(250, 0, 0), 0.8f);

        // ���ư��� ��ư
        GobackBtn.transform.DOLocalMove(new Vector3(0, -450, 0), 0.8f);

        // ��ư ��Ȱ��ȭ
        StartBtn.SetActive(false);
        tutorialBtn.SetActive(false);
        ExitBtn.SetActive(false);
        TitlePanel.SetActive(false);
    }

    public void OnClickGoBack() // ���ư��� ��ư Ŭ����
    {
        this.audio.Play();

        RectPanel.transform.DOLocalMove(new Vector3(-250, 3000, 0), 0.8f);
        HexPanel.transform.DOLocalMove(new Vector3(250, 3000, 0), 0.8f);
        GobackBtn.transform.DOLocalMove(new Vector3(0, 2500, 0), 0.8f);

        StartBtn.SetActive(true);
        tutorialBtn.SetActive(true);
        ExitBtn.SetActive(true);
        TitlePanel.SetActive(true);
    }

    public void OnClickTut() // Ʃ�丮�� ��ư Ŭ����
    {
        this.audio.Play();

        tutOutBtn.SetActive(true);
        tutPanel.SetActive(true);

        ExitBtn_B.interactable = false;
        tutBtn_B.interactable = false;
    }

    public void OnClickTutOut() // Ʃ�丮�� X ��ư Ŭ����
    {
        this.audio.Play();

        tutOutBtn.SetActive(false);
        tutPanel.SetActive(false);

        ExitBtn_B.interactable = true;
        tutBtn_B.interactable = true;
    }

    public void OnClick_RectStart() // �簢�� ���ý�
    {
        this.audio.Play();

        SceneManager.LoadScene("PlaySquare");
    }

    public void OnClick_Hexagon() // ������ ���ý�
    {
        this.audio.Play();

        SceneManager.LoadScene("PlayHexagon");
    }

    public void OnClickExit()
    {
        Debug.Log("������");
        Application.Quit();
    }

    /*
    public void OnCliick_SoundOff() // ���� ���� �ϱ� (���� ON �̹��� Ŭ��)
    {
        this.audio.Play();

        AudioListener.volume = 0; // ���� ��� ���߱�

        SoundOnBtn.SetActive(false);
        SoundOffBtn.SetActive(true);
    }

    public void OnCliick_SoundON() // ���� �ְ� �ϱ� (���� OFF �̹��� Ŭ��)
    {
        AudioListener.volume = 1; // ���� �ٽ� ���

        SoundOnBtn.SetActive(true);
        SoundOffBtn.SetActive(false);
        
    }
    */

    public void OnclickOnOff() // ���� ����
    {
        if(OnOff)
        {
            AudioListener.volume = 0;
            OnOff = false;
        }
        else
        {
            AudioListener.volume = 1;
            OnOff = true;
        }
    }


}
