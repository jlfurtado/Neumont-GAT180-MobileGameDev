using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public Text shotsRemainingText;
    public int pointsPerExtraBall = 1000;
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
            OnLevelLose();
        }
    }

    public void ResetShot(GameObject shot)
    {
        // TODO: validate shot is a projectile!??!?!

        ResetMeIfNotMoving rminm = shot.GetComponent<ResetMeIfNotMoving>();
        if (rminm != null) { rminm.ResetReset(); }

        DisableWhenBelow dbw = shot.GetComponent<DisableWhenBelow>();
        if (dbw != null) { dbw.Reset(); }

        shotsToDie--;
        currentShots++;

        SetShotText();

        shot.SetActive(false);
        shot.GetComponent<Renderer>().enabled = false;
        StopShot(shot);
    }

    private void StopShot(GameObject shot)
    {
        Rigidbody rbs = shot.GetComponent<Rigidbody>();
        rbs.velocity = Vector3.zero;
        rbs.angularVelocity = Vector3.zero;
    }

    private void SetShotText()
    {
        shotsRemainingText.text = "Shots Remaining: " + currentShots;
    }

    public bool AreShotsLeft()
    {
        return currentShots > 0;
    }

    public int GetNextShotIndex()
    {
        return Mathf.Clamp(maxShots - currentShots, 0, maxShots - 1);
    }

    private void OnLevelWin()
    {
        AddEndScore();
        scoreManager.SetDidWin(true);
        sceneMover.MoveToVictory();
    }

    private void OnLevelLose()
    {
        AddEndScore();
        sceneMover.MoveToLoss();
    }

    private void AddEndScore()
    {
        scoreManager.AddScore(pointsPerExtraBall * currentShots);
    }
}
