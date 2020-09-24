using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

}
