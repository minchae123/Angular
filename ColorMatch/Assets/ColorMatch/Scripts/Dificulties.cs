using UnityEngine;
using System.Collections;

public class Dificulties : MonoBehaviour {

    [Tooltip("How often decrease spawn delay rate in seconds")]
    public float decreaseEvery = 60;
    [Tooltip("Decrease value")]
    public float decreaseRate = 0.15F;
    [Tooltip("Minimum spawn rate, decreasing will not be done if spawn rate reaches this value")]
    public float minSpawnRate = 0.5F;
    private SpawnManager SM;
    private float decreaseTime;
    private float time;

    void Awake()
    {
        this.enabled = false;   // Disable by default, we will enable it when the game will start (see GameStart script);
    }

	// Use this for initialization
	void Start () 
    {
        SM = GetComponent<SpawnManager>();
        decreaseTime = decreaseEvery;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Getting game time;
        time = SpawnManager.gameTime;

        //Decrease spawn rate;
        if (!GameManager.gameOver && SM.spawnRate > minSpawnRate)
        {
            if (decreaseTime < time)
            {
                SM.spawnRate -= decreaseRate;
                decreaseTime = time + decreaseEvery;
            }
        }
        else
            decreaseTime = decreaseEvery;
	}
}
