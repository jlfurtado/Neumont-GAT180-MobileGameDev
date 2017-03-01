using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public Text shotsRemainingText;
    public SceneMover sceneMover;
    public int maxShots = 5;
    private int currentShots;
    private int shotsToDie;

    // Use this for initialization
    void Start() {
        shotsToDie = 0;
        currentShots = maxShots;
        SetShotText();
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
            sceneMover.MoveToTitle(); // TODO: MOVE TO VICTORY/GAMEOVER
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
}
