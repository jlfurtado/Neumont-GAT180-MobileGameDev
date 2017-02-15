using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour {

    public bool IsCardRotating = false;
    private CardManager currentFlippedCard;
    public Sprite[] cardImages;

    // Use this for initialization
    void Start () {
        currentFlippedCard = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCardClicked(CardManager cm)
    {
        // if a card is currently flipped
        if (currentFlippedCard != null)
        {
            if (currentFlippedCard.ImageIndex == cm.ImageIndex)
            {
                TellCardToDie(cm);
                TellCardToDie(currentFlippedCard);
                currentFlippedCard = null;
                IsCardRotating = false;
            }
        }
        else
        {
            currentFlippedCard = cm;
            IsCardRotating = true;
            cm.StartFlip();
        }
    }

    private void TellCardToDie(CardManager cm)
    {
        cm.OnMatched();
    }

    public void OnCardFlipEnd()
    {
        IsCardRotating = false;
    }
}
