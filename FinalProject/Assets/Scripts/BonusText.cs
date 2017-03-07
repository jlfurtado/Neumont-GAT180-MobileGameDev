using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BonusText : MonoBehaviour {
    private Color goodColor = Color.green;
    private Color badColor = Color.red;
    private float timer = 0.0f;
    private Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
        text.text = "";
    }

	public void ResetText(int score, float time)
    {
        timer = time;
        string colorHex = ColorUtility.ToHtmlStringRGB(((score < 0) ? badColor : goodColor));
        text.text += ("<color=" + "\"#" + colorHex + "\"" + ">")+ (score > 0 ? "+" : "") + score + "</color>\n";
        text.enabled = true;
    }

    void Update ()
    {
        timer -= Time.deltaTime;

        if (timer < 0.0f && text.enabled)
        {
            DisableText();
        }	
	}

    private void DisableText()
    {
        timer = 0.0f;
        text.enabled = false;
        text.text = "";
        
    }
}
