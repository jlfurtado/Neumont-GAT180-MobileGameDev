using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float TimeRemaining = 30.0f;
    public GameManager GM;
    public Text TimeRemainingText;
    private bool isOver;
    private const int NUM_CHARS = 6;

    void Start()
    {
        TimeRemaining = Difficulty.StartTime;
    }

	// Update is called once per frame
	void Update ()
    {
        TimeRemaining -= Time.deltaTime;
        isOver = TimeRemaining <= 0.0f;
        SetText();

        if (isOver)
        {
            GM.GoToGameOverScene();
        }
	}

    private void SetText()
    {
        string timeString = TimeRemaining.ToString();
        TimeRemainingText.text = "Text: " + timeString.Substring(0, Mathf.Min(NUM_CHARS, timeString.Length));
    }
}
