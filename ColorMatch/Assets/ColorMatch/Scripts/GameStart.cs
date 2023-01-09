using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStart : MonoBehaviour {

    public GameObject startPanel;           //Start game UI panel;
    public Slider volumeSlider;             //Game sounds volume;
    public Text TapHint;                    //Start hint text object;
    public MonoBehaviour[] gameScripts;     //Game scripts;

    private bool fadeOutPanel;
    private bool isGameStarted;
    private CanvasGroup panelAlpha;
    private CanvasGroup hintAlpha;

	// Use this for initialization
	void Start ()
    {
        volumeSlider.value = LoadVolume();                              //Load volume from player prefs;
        AudioListener.volume = volumeSlider.value;                      //Set audio listener volume;
        //Cache canvas group components;
        panelAlpha = startPanel.GetComponent<CanvasGroup>();            
        hintAlpha = TapHint.gameObject.AddComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Do nothing if start panel disabled;
        if (!startPanel.activeSelf || !startPanel.activeInHierarchy)
            return;

        //Making start hint flickering;
        hintAlpha.alpha = Mathf.PingPong(Time.time * 2, 1);

        //Check if we tapped, and the tap was on the lower screen part, becouse there is a volume slider on top;
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height / 2)
            fadeOutPanel = true;    //Set fadeout to true;

        //Fade out start panel;
        if (fadeOutPanel)
            panelAlpha.alpha = Mathf.MoveTowards(panelAlpha.alpha, 0, 2 * Time.deltaTime);

        //If start panel faded out, enable our game scripts;
        if(panelAlpha.alpha == 0 && !isGameStarted)
        {
            for(int i = 0; i < gameScripts.Length; i++)
            {
                gameScripts[i].enabled = true;
            }

            TapHint.enabled = false;        //Disable start hint text;
            SaveVolume();                   //Save volume;
            isGameStarted = true;           //Set gameStarted flag to true;
            startPanel.SetActive(false);    //Disable start panel, we dont need it anymore;
        }
	}

    //Load volume function;
    float LoadVolume()
    {
        if (PlayerPrefs.HasKey("Vol"))
            return PlayerPrefs.GetFloat("Vol");
        return 1;
    }

    //Save volume function;
    void SaveVolume()
    {
        PlayerPrefs.SetFloat("Vol", volumeSlider.value);
    }
}
