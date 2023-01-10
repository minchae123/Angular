using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public TextMeshProUGUI overScoreTxt;
    public TextMeshProUGUI overBestScoreTxt;

    private void Start()
    {
        scoreTxt.text = GameManager.instance.score.ToString();
    }

    private void Update()
    {
        scoreTxt.text = GameManager.instance.score.ToString();
        overScoreTxt.text = $"Á¡¼ö : {GameManager.instance.score.ToString()}" ;
        overBestScoreTxt.text = GameManager.instance.bestScore.ToString();
    }



}
