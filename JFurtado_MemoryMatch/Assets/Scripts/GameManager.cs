using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public struct CardLoc
{
    public CardLoc(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int x;
    public int y;
}

public class GameManager : MonoBehaviour {

    public GameObject CardPrefab;
    public GameObject CardHolder;

    public float cardSizeFactorX; // how many cards can fit in the x at a scale of 1
    public float cardSizeFactorY; // how many cards can fit in the y at a scale of 1

    public float spacingX;
    public float spacingY;

    private System.Random rand;

    void Start()
    {
        rand = new System.Random();
        InitializeGame(Difficulty.Width, Difficulty.Height);
    }

    public void GoToVictoryScene()
    {
        SceneManager.LoadScene(Strings.VictorySceneName);
    }

    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(Strings.GameOverSceneName);
    }

    private void InitializeGame(int width, int height)
    {
        float cardScaleX = cardSizeFactorX / width;
        float cardScaleY = cardSizeFactorY / height;

        // TODO DITCH MIDDLE CARD + CENTER ON PARENT
        float halfWidth = width / 2.0f - 0.5f;
        float halfHeight = height / 2.0f - 0.5f;
        int next = 0;
        int mod = (width * height)/2;
        CardGameManager cgm = CardHolder.GetComponent<CardGameManager>();
        cgm.NumCardPairs = mod;

        List<CardLoc> remainingLocs = new List<CardLoc>();
        for(int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                if (!IsCenterCard(x, y, width, height))
                {
                    remainingLocs.Add(new CardLoc(x, y));
                }
            }
        }

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                if (IsCenterCard(x, y, width, height)) { continue; }
                int locIndex = rand.Next(0, remainingLocs.Count);
                GameObject currentCard = Instantiate(CardPrefab, new Vector3(cardScaleX * (remainingLocs[locIndex].x - halfWidth) * spacingX, cardScaleY * (remainingLocs[locIndex].y - halfHeight) * spacingY, 0.0f), new Quaternion(), CardHolder.transform);
                remainingLocs.RemoveAt(locIndex);

                CardManager cm = currentCard.GetComponent<CardManager>();

                currentCard.transform.localScale = new Vector3(cardScaleX, cardScaleY, 1.0f);
                currentCard.GetComponent<SpriteRenderer>().sprite = cgm.cardBackImage;
                cm.ImageIndex = next;
                cm.StartFlip(cgm.cardImages[next]);
                next = ((next + 1) % mod);
            }
        }
    }

    private bool IsCenterCard(int x, int y, int width, int height)
    {
        // there is only a center card if the width and the height are odd
        if ((width * height) % 2 == 0) { return false; }

        // if there is a center, check if the indices match half of the dimmension
        return ((x == (width / 2)) && (y == (height / 2)));
    }
}
