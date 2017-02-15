using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour {

    public bool IsCardRotating = false;
    public GameManager GM;
    private CardManager currentFlippedCard;
    private CardManager lastFlippedCard;
    public Sprite[] cardImages;
    public Sprite cardBackImage;
    public int NumCardPairs;
    private bool waitingForCheck;

    // Use this for initialization
    void Start () {
        currentFlippedCard = null;
        waitingForCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (waitingForCheck)
        {
            if (!currentFlippedCard.isRotating)
            {
                // clicked two cards that match
                if (lastFlippedCard.ImageIndex == currentFlippedCard.ImageIndex)
                {
                    TellCardToDie(lastFlippedCard);
                    TellCardToDie(currentFlippedCard);
                    NumCardPairs--;

                    CheckWinCondition();
                }
                else // clicked a card that didn't match
                {
                    // want to flip the card to show it didn't match, then return them both to normal
                    lastFlippedCard.StartFlip(cardBackImage);
                    currentFlippedCard.StartFlip(cardBackImage);
                }

                IsCardRotating = true;
                lastFlippedCard = null;
                currentFlippedCard = null;
                waitingForCheck = false;
            }
        }
	}

    public void OnCardClicked(CardManager cm)
    {
        if (currentFlippedCard != null)
        {
            lastFlippedCard = currentFlippedCard;
            waitingForCheck = true;
        }

        currentFlippedCard = cm;
        IsCardRotating = true;
        cm.StartFlip(cardImages[cm.ImageIndex]);
    }

    private void TellCardToDie(CardManager cm)
    {
        cm.OnMatched();
    }

    public void OnCardFlipEnd()
    {
        IsCardRotating = false;
    }

    private void CheckWinCondition()
    {
        if (NumCardPairs <= 0)
        {
            GM.GoToVictoryScene();   
        }
    }
}
