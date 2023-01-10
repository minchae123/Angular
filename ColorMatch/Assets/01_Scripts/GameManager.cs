using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    
    public int bestScore = 0;
    private string keyName = "BestScore";


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

        bestScore = PlayerPrefs.GetInt(keyName, 0);
    }

    private void Update()
    {
        if(score > bestScore)
        {
            PlayerPrefs.SetInt(keyName, score);
        }
    }
}
