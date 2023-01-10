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
            uIManager.UpSlide();
        }
    }
}
