using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject Button2;
    public GameObject Button3;

    void UnLock2Botton()
    {
        Lock2.SetActive(false);
        Button2.SetActive(true);
    }

    void UnLock3Botton()
    {
        Lock3.SetActive(false);
        Button3.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Lock2.SetActive(true);
        Button2.SetActive(false);
        Lock3.SetActive(true);
        Button3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("1Bestscore") >= 100)
        {
            UnLock2Botton();
        }
        
        if(PlayerPrefs.GetInt("2Bestscore") >= 150)
        {
            UnLock3Botton();
        }
    }
}
