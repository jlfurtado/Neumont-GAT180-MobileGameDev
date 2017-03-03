using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int storeScore;
    public Text scoreText;
    public int levelIndex = 0;
    private int scoreValue = 0;
    private int highScore = 0;
    private bool didWin = false;

    void Start()
    {
        highScore = PlayerPrefs.GetInt(Strings.HIGH_SCORE_KEYS[levelIndex], 0);
    }

    public void AddScore(int value)
    {
        scoreValue += value;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + scoreValue;
    }
    
    public void SetDidWin(bool won)
    {
        didWin = won;
    }

    void OnDisable()
    {
        storeScore = scoreValue;

        if (scoreValue > highScore && didWin)
        {
            PlayerPrefs.SetInt(Strings.HIGH_SCORE_KEYS[levelIndex], scoreValue);
            PlayerPrefs.Save();
        }
    }
}
