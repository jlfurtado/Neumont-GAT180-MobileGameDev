using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarController : MonoBehaviour {
    public Image backImage;
    public Image frontImage;
    public PlayerController playerController;
    private float heightStore;

	// Use this for initialization
	void Start () {
        heightStore = frontImage.rectTransform.sizeDelta.y;

    }
	
	// Update is called once per frame
	void Update () {
        float currentWidth = playerController.GetLaunchStrength() * backImage.rectTransform.sizeDelta.x;
        frontImage.rectTransform.sizeDelta = new Vector2(currentWidth, heightStore);
	}
}
