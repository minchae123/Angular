using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public Text scoreText;              //Text object to display current score;
    public Text bestText;               //Text object to display best score;
    public GameObject gameoverPanel;    //Game over UI panel;
    public Text gameoverText;           //Text object to display score on game over;
    public Button ReplayBtn, QuitBtn;   //Replay and Quit buttons;
    public AudioClip clickSfx;          //Click sound effect;

    public static int score;
    public static bool gameOver;
    private static AudioSource audioSource;

    private int bestScore;

    private CanvasGroup panelAlpha;
    private SpawnManager SM;
    

    void Awake()
    {
        this.enabled = false;   // Disable by default, we will enable it when the game will start (see GameStart script);
    }

	void Start ()
    {
        //Сaching components;
        audioSource = GetComponent<AudioSource>();
        SM = GetComponent<SpawnManager>();
        panelAlpha = gameoverPanel.GetComponent<CanvasGroup>();

        //Hiding game over panel and disable its interactivity;
        panelAlpha.alpha = 0;
        panelAlpha.interactable = false;

        //Adding button listeners;
        ReplayBtn.onClick.AddListener(() => 
        { 
            Restart(); 
            PlaySound(clickSfx); 
        });

        QuitBtn.onClick.AddListener(() => 
        { 
            Application.Quit();
            PlaySound(clickSfx); 
        });
        
        //Loading best score;
        bestScore = LoadBestScore();
	}
	
	void Update ()
    {
        //Setting our text objects to display the scores;
        bestText.text = bestScore > 0 ? "BEST: " + bestScore : "";
        scoreText.text = "SCORE: " + score.ToString();

        //Enable game over panel if gameOver true;
        panelAlpha.alpha = gameOver ? Mathf.MoveTowards(panelAlpha.alpha, 1, 2 * Time.deltaTime) : 0;
        panelAlpha.interactable = panelAlpha.alpha > 0.5F;

        //Setting game over text based on the current score;
        if(gameOver)
        {
            if (score > bestScore)
                gameoverText.text = "NEW BEST SCORE" + "\n" + score;
            else
                gameoverText.text = "YOUR SCORE" + "\n" + score;
        }
	}

    //Function for score changing, its static, so we can call it from any script without refference (See 'Circle' script);
    public static void AddScore()
    {
        score++;
    }

    //Function for changing gameOver state;
    public static void GameOver(bool gameOverState)
    {
        gameOver = gameOverState;
    }

    //Restart
    public void Restart()
    {
        //If current score is bigger than best, saving it and override our bestScore value;
        if (score > bestScore)
        {
            SaveBestScore(score);
            bestScore = score;
        }
        //After saving is done, we reseting score and spawn manager, and setting gameOver state to false; 
        score = 0;
        SM.Reset();
        gameOver = false;
    }

    //Function to play audio;
    public static void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    //Save best score function;
    private void SaveBestScore(int value)
    {
        PlayerPrefs.SetInt("Best", value);
    }

    //Load best score function;
    private int LoadBestScore()
    {
        return PlayerPrefs.GetInt("Best");
    }
}
