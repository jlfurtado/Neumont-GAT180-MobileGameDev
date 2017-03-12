using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BonusText : MonoBehaviour {
    private Color goodColor = Color.green;
    private Color badColor = Color.red;
    private float timer = 0.0f;
    private float totalTime;
    private Text text;
    private float moveAmount;
    private Vector3 basePosition;
    
    void Start()
    {
        basePosition = transform.position;
        text = GetComponent<Text>();
        text.enabled = false;
        text.text = "";
    }

	public void ResetText(int score, float time, float moveAmount)
    {
        this.moveAmount = moveAmount;
        timer = time;
        totalTime = time;
        string colorHex = ColorUtility.ToHtmlStringRGB(((score < 0) ? badColor : goodColor));
        text.text += ("<color=" + "\"#" + colorHex + "\"" + ">")+ (score > 0 ? "+" : "") + score + "</color>\n";
        text.enabled = true;
    }

    void Update ()
    {
        timer -= Time.deltaTime;

        if (totalTime > 0.0f && text.enabled)
        {
            transform.position = basePosition + new Vector3(0.0f, (moveAmount * (totalTime - timer) / totalTime), 0.0f);
        }

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
        transform.position = basePosition;
    }
}
