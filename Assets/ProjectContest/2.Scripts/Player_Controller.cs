using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    ScoreManager theScoreManager;
    TimingManager theTimingManager;
    PlayerHealth thePlayerHealth;
    
    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //���� üũ
            theTimingManager.CheckTiming();
        }
    }

   

}
