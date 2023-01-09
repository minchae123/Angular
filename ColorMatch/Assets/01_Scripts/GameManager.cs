using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject tileParent;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveLeft()
    {
        //tileParent.transform.rotation = Quaternion.(0, 0, tileParent.transform.rotation.z - 90);
    }

    public void MoveRight()
    {
        tileParent.transform.rotation = Quaternion.Euler(0, 0, tileParent.transform.rotation.z + 90);
    }
}
