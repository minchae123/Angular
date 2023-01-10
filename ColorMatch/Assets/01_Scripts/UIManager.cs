using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    private void Start()
    {
        scoreTxt.text = GameManager.instance.score.ToString();
    }

    private void Update()
    {
        scoreTxt.text = GameManager.instance.score.ToString();
    }
}
