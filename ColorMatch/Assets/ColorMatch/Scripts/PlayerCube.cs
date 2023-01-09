using UnityEngine;
using System.Collections;

public class PlayerCube : MonoBehaviour {
    public float turnAngle = 90;    // Angle to turn in degrees;
    public float turnSpeed = 15;    // Turn speed;

    private float angle;
    private Transform thisT;

    void Awake()
    {
        this.enabled = false;   // Disable by default, we will enable it when the game will start (see GameStart script);
    }

	// Use this for initialization
	void Start () 
    {
        //Cache transform;
        thisT = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Setting angle, based on touch position.
        if (!GameManager.gameOver && Input.GetMouseButtonDown(0))
            angle += Input.mousePosition.x < Screen.width / 2 ? turnAngle : -turnAngle;

        //Rotating cube on desired angle;
        thisT.rotation = Quaternion.Slerp(thisT.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * turnSpeed);
	}
}
