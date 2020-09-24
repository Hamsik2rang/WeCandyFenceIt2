using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    private float timer;
    private int waitingTime;
    bool isAlive;

    void Start()
    {
        isAlive = true;
        timer = 0.0f;
        waitingTime = 5;
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        // 5초 뒤 Player 사망
        if (timer > waitingTime)
        {
            isAlive = false;
            timer = 0.0f;
        }

        if (!isAlive)
        {
            GameOver();
        }
    }

    // 게임오버 시 ResultScene 불러오기
    void GameOver()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
