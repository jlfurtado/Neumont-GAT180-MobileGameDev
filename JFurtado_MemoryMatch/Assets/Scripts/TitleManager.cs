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
        // easy has more time and less cards to match (8 in a 3x3 square)
        Difficulty.StartTime = 60.0f;
        Difficulty.Width = 3;
        Difficulty.Height = 3;
    }

    public void SetMediumTime()
    {
        // medium has medium time and medium cards to match (16 in a 4x4 square)
        Difficulty.StartTime = 45.0f;
        Difficulty.Width = 4;
        Difficulty.Height = 4;
    }

    public void SetHardTime()
    {
        // hard has less time and more cards to match (24 in a 5x5 square)
        Difficulty.StartTime = 30.0f;
        Difficulty.Width = 5;
        Difficulty.Height = 5;
    }
}