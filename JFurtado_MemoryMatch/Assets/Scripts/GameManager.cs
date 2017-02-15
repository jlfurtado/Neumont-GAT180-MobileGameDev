using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject CardPrefab;
    public GameObject CardHolder;

    public float cardSizeFactorX; // how many cards can fit in the x at a scale of 1
    public float cardSizeFactorY; // how many cards can fit in the y at a scale of 1

    public float spacingX;
    public float spacingY;

    void Start()
    {
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

        Sprite[] cardHolderImages = CardHolder.GetComponent<CardGameManager>().cardImages;

        // TODO DITCH MIDDLE CARD + CENTER ON PARENT
        float halfWidth = width / 2.0f - 0.5f;
        float halfHeight = height / 2.0f - 0.5f;
        int next = 0;
        int mod = (width * height)/2;
        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                if (IsCenterCard(x, y, width, height)) { continue; }
                GameObject currentCard = Instantiate(CardPrefab, new Vector3(cardScaleX * (x - halfWidth) * spacingX, cardScaleY * (y - halfHeight) * spacingY, 0.0f), new Quaternion(), CardHolder.transform);
                currentCard.transform.localScale = new Vector3(cardScaleX, cardScaleY, 1.0f);
                currentCard.GetComponent<SpriteRenderer>().sprite = cardHolderImages[next];
                currentCard.GetComponent<CardManager>().ImageIndex = next;
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
