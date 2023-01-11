using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject nemo;
    public GameObject square;
    public GameObject hexagon;
    public GameObject oxtagon;

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

        if(score >= 500)
        {
            is1 = true;
        }

        if(score >= 1000)
        {
            is2 = true;
        }

        if(score >= 1500)
        {
            is3 = true;
        }

        if(score >= 2000)
        {
            is4 = true;
        }
    }
}
