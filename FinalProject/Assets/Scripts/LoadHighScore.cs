using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoadHighScore : MonoBehaviour {
    public int levelIndex = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt(Strings.HIGH_SCORE_KEYS[levelIndex], 0);
	}
}
