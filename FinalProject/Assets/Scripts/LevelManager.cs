using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class LevelManager : MonoBehaviour {
    public Text shotsRemainingText;
    public Text goldCubesRemainingText;
    public int pointsPerExtraBall = 1000;
    public SceneMover sceneMover;
    public ScoreManager scoreManager;
    public int maxShots = 5;
    private int currentShots;
    private int shotsToDie;
    public int totalRequiredObjects = 3;
    private int currentRequiredObjectsLeft;
    private const float loseWinCheckTime = 3.0f;
    private bool didWinOrLose = false;
    private AudioSource audio;

    // Use this for initialization
    void Start() {
        audio = GetComponent<AudioSource>();
        shotsToDie = 0;
        currentShots = maxShots;
        SetShotText();
        currentRequiredObjectsLeft = totalRequiredObjects;
        SetGoldCubesText();

        StartCoroutine(CheckLoseWin(loseWinCheckTime));
    }

    private IEnumerator CheckLoseWin(float interval)
    {
        while (!didWinOrLose)
        { 
            // if both win and lose conditions are true, give the player victory
            if (currentRequiredObjectsLeft <= 0)
            {
                OnLevelWin();
            }
            else if (shotsToDie <= 0 && currentShots <= 0)
            {
                OnLevelLose();
            }

            yield return new WaitForSeconds(interval);
        }
    }

    public void OnRequiredObjectDestroyed()
    {
        currentRequiredObjectsLeft--;
        SetGoldCubesText();
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
    }

    public void ResetShot(GameObject shot)
    {
        ResetShotCompletely(shot);

        shotsToDie--;
        currentShots++;

        SetShotText();

        DisableGameObject(shot);
        audio.Play();
    }

    private void SetShotText()
    {
        shotsRemainingText.text = "Shots Remaining: " + currentShots;
    }

    private void SetGoldCubesText()
    {
        goldCubesRemainingText.text = "Gold Cubes Left: " + currentRequiredObjectsLeft;
    }

    public bool AreShotsLeft()
    {
        return currentShots > 0;
    }

    private void OnLevelWin()
    {
        didWinOrLose = true;
        AddEndScore();
        scoreManager.SetDidWin(true);
        sceneMover.MoveToVictory();
    }

    private void OnLevelLose()
    {
        didWinOrLose = true;
        AddEndScore();
        sceneMover.MoveToLoss();
    }

    private void AddEndScore()
    {
        scoreManager.AddScore(pointsPerExtraBall * currentShots);
    }

    public static void ResetShotCompletely(GameObject shot)
    {
        ResetMeIfNotMoving rminm = shot.GetComponent<ResetMeIfNotMoving>();
        if (rminm != null) { rminm.ResetReset(); } else { Debug.Log("MAYBE NOT A SHOT"); }

        DisableWhenBelow dbw = shot.GetComponent<DisableWhenBelow>();
        if (dbw != null) { dbw.Reset(); } else { Debug.Log("MAYBE NOT A SHOT"); }

        Rigidbody rb = shot.GetComponent<Rigidbody>();
        if (rb != null) { StopRB(rb); } else { Debug.Log("MAYBE NOT A SHOT"); }
    }

    private static void StopRB(Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public static void DisableGameObject(GameObject gob)
    {
        gob.SetActive(false);
        gob.GetComponent<Renderer>().enabled = false;
        gob.transform.position = Vector3.zero;
    }
}
