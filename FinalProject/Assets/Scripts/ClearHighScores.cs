using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearHighScores : MonoBehaviour {

	public void ClearTheScores()
    {
        for (int i = 0; i < Strings.HIGH_SCORE_KEYS.Length; ++i)
        {
            PlayerPrefs.SetInt(Strings.HIGH_SCORE_KEYS[i], 0);
        }

        PlayerPrefs.Save();
    }
}
