using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public void GoToGameScene()
    {
        SceneManager.LoadScene(Strings.GameSceneName);
    }

    public void SetEasyTime()
    {
        Difficulty.StartTime = 60.0f;
        Difficulty.Width = 3;
        Difficulty.Height = 2;
    }

    public void SetMediumTime()
    {
        Difficulty.StartTime = 45.0f;
        Difficulty.Width = 3;
        Difficulty.Height = 3;
    }

    public void SetHardTime()
    {
        Difficulty.StartTime = 30.0f;
        Difficulty.Width = 5;
        Difficulty.Height = 4;
    }
}