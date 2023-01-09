using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public Transform[] SpawnPrefabs;    // Falling down prefabs;
    public float spawnYOffset = 0.1F;
    public float startDelay = 3;        // Delay before game start;
    public float spawnRate = 1.5F;      // Objects spawn rate;
    public Text CountdownText;          // Text object to display current delay value;

    private float countdown;
    private Vector3 spawnPoint;
    private float spawnTime;
    private float defaultSpawnRate;
    public static float gameTime;

    void Awake()
    {
        this.enabled = false;   // Disable by default, we will enable it when the game will start (see GameStart script);
    }

	// Use this for initialization
	void Start () 
    {
        //Calculate spawn position (middle top)
        spawnPoint = Camera.main.ViewportToWorldPoint(new Vector2(0.5F, 1));
        spawnPoint.z = 0;
        spawnPoint.y += spawnYOffset;


        spawnTime = startDelay;        // Set first spawn time equal to the start delay;
        countdown = startDelay;        // Set countdoun counter equal to the start delay;
        defaultSpawnRate = spawnRate;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // If countdown value is bigger then 0, decrease it;
        if (countdown > 0)
            countdown -= 1 * Time.deltaTime;
        else
            CountdownText.enabled = false; // If countdown value is zero or less, desable countdown text, we dont need it anymore;

        //Display countdown value;
        CountdownText.text = countdown > 1 ? countdown.ToString("F0") : "GO!";

        //Implementing Time.time replacement, so we can reset it when needed;
        gameTime += 1 * Time.deltaTime;

        //If gameOver is false, spawn our objects using primitive timer.
        if (!GameManager.gameOver && spawnTime < gameTime)
        {
            Instantiate(SpawnPrefabs[Random.Range(0, SpawnPrefabs.Length)], spawnPoint, Quaternion.identity);
            spawnTime = gameTime + spawnRate;
        }
	}

    //Reset changes;
    public void Reset()
    {
        gameTime = 0;
        spawnTime = startDelay;
        countdown = startDelay;
        spawnRate = defaultSpawnRate;
        CountdownText.enabled = true;
    }
}
