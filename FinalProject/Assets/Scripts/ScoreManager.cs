using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    private long scoreValue;
    
    public void AddScore(long value)
    {
        scoreValue += value;
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + scoreValue;
    }
    
}
