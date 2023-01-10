using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    // 패널
    public GameObject RectPanel;
    public GameObject HexPanel;

    // 버튼
    public GameObject StartBtn;
    public GameObject tutorialBtn;

    // Move
    public GameObject targetPosition;
    Vector3 vel = Vector3.zero;

    private void Awake()
    {
        if (RectPanel != null)
        {
            RectPanel.SetActive(false);
        }
        if (HexPanel != null)
        {
            HexPanel.SetActive(false);
        }
    }

    public void OnClickStart()
    {
        if (RectPanel != null)
        {
            RectPanel.SetActive(true);
        }
        if (HexPanel != null)
        {
            HexPanel.SetActive(true);
        }

        if (StartBtn != null)
        {
            StartBtn.SetActive(false);
        }
        if (tutorialBtn != null)
        {
            tutorialBtn.SetActive(false);
        }
    }

}
