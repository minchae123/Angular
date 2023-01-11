using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private UIManager uIManager;

    public int score;
    
    public int bestScore = 0;
    private string keyName = "BestScore";

    public int health = 2;
    public Animator[] heart;

    public AudioManager audioManager;
    public AudioClip GameOverAudio;
    AudioSource audioSource;

    public GameObject[] tiles;
    public int level = 0;

    public TextMeshProUGUI upgradeTxt;
    public TextMeshProUGUI countTxt;

    public bool is1 = false;
    public bool is2 = false;
    public bool is3 = false;
    public bool is4 = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        audioSource = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager>();
        uIManager = FindObjectOfType<UIManager>();
        bestScore = PlayerPrefs.GetInt(keyName, 0);
    }

    private void Update()
    {
        if(score > bestScore)
        {
            PlayerPrefs.SetInt(keyName, score);
        }

        if(health < 0)
        {
            BallMove b = FindObjectOfType<BallMove>();
            if(b != null)
            {
                Destroy(b.gameObject);
                BallSpawn.instance.StopAllCoroutines();
            }
            uIManager.UpSlide();

            audioSource.PlayOneShot(GameOverAudio);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            score += 100;
        }
    }

    public IEnumerator LevelSetting(int level)
    {
        for(int i = 0; i < 4; i++)
        {
            upgradeTxt.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            upgradeTxt.gameObject.SetActive(false);
        }

        tiles[level - 1].SetActive(false);
        yield return new WaitForSeconds(2);
        tiles[level].SetActive(true);
    }

    
    public IEnumerator CountDown()
    {
        countTxt.text = "3";
        countTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countTxt.text = "2";
        yield return new WaitForSeconds(1);
        countTxt.text = "1";
        yield return new WaitForSeconds(1);
        countTxt.text = "GO!";
        yield return new WaitForSeconds(1);
        countTxt.gameObject.SetActive(false);
        countTxt.text = "3";
    }
}
