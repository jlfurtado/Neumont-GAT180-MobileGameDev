using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class MoveToNextSceneAfterTime : MonoBehaviour {

    #region Data

    public string NextSceneName = "SCENE NOT SET"; // stores which scene to move to
    public float TotalTime = 5.0f; // stores the total amount of time to wait to move to the next scene
    public int NumChars = 4; // stores the number of characters to set on the string
    private float timeRemaining; // manages the remaining time, to update text and move to next scene when no time remains
    private Text text; // references the text object on the same game object as this script, so it can set it

    #endregion

    #region Start

    // Use this for initialization
    void Start () {
        // grab the text component + initialize the timer
        timeRemaining = TotalTime;
        text = GetComponent<Text>();
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update () {
        // update timer
        timeRemaining -= Time.deltaTime;

        // update text based on timer
        setText();

        // if the time is over, move to the next scene
        if (timeRemaining < 0.0f)
        {
            SceneManager.LoadScene(NextSceneName);
        }
	}

    #endregion

    #region Helper Methods
    
    private void setText()
    {
        // set the text to the string and value of remaining time concatenated
        text.text = "Time Remaining: " + timeRemaining.ToString().Substring(0, NumChars);
    }

    #endregion
}
