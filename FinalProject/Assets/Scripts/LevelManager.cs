using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public Text shotsRemainingText;
    public SceneMover sceneMover;
    public ScoreManager scoreManager;
    public int maxShots = 5;
    private int currentShots;
    private int shotsToDie;
    public int totalRequiredObjects = 3;
    private int currentRequiredObjectsLeft;

    // Use this for initialization
    void Start() {
        shotsToDie = 0;
        currentShots = maxShots;
        SetShotText();
        currentRequiredObjectsLeft = totalRequiredObjects;
    }

    public void OnRequiredObjectDestroyed()
    {
        currentRequiredObjectsLeft--;

        if (currentRequiredObjectsLeft <= 0)
        {
            OnLevelWin();
        }
    }

    public void OnFireShot()
    {
        currentShots--;
        shotsToDie++;
        SetShotText();
    }

    public void OnProjectileDestroyed()
    {
        shotsToDie--;

        if (shotsToDie <= 0 && currentShots <= 0)
        {
            sceneMover.MoveToLoss(); // TODO: MOVE TO VICTORY/GAMEOVER
        }
    }

    public void ResetShot(GameObject shot)
    {
        // TODO: validate shot is a projectile!??!?!

        shotsToDie--;
        currentShots++;

        SetShotText();

        shot.SetActive(false);
        shot.GetComponent<Renderer>().enabled = false;
        Destroy(shot);
    }

    private void SetShotText()
    {
        shotsRemainingText.text = "Shots Remaining: " + currentShots;
    }

    public bool AreShotsLeft()
    {
        return currentShots > 0;
    }

    private void OnLevelWin()
    {
        scoreManager.SetDidWin(true);
        sceneMover.MoveToVictory();
    }
}
