using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float HorizontalRotateSpeed = 1.0f;
    public float VerticalRotateSpeed = 1.0f;
    public float OffsetInLaunchDir = 1.75f;
    public float LaunchForceStrength = 25.0f;
    public GameObject projectilePrefab;
    public LevelManager levelManager;

    private float timer = 0.0f;
    private float totalRotationX = 0.0f;
    private float totalRotationY = 0.0f;

    private const float maxRotationY = 90.0f;
    private const float minRotationY = 0.0f;
    private const float maxRotationX = 45.0f;
    private const float minRotationX = -45.0f;
    private const float maxPowerHoldTime = 3.0f;
    private const float minFireHoldTime = 0.1f;
    //private const float fireScaleThreshold = maxPowerHoldTime - minFireHoldTime;
    private GameObject[] bullets;

    // Use this for initialization
    void Start () {
        bullets = new GameObject[levelManager.maxShots];

        for (int i = 0; i < levelManager.maxShots; ++i)
        {
            bullets[i] = Instantiate(projectilePrefab);

            bullets[i].GetComponent<NotifyWhenDestroyed>().levelManager = levelManager;
            bullets[i].GetComponent<ResetMeIfNotMoving>().levelManager = levelManager;
            LevelManager.DisableGameObject(bullets[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        UpdateRotation();
        HandleFiring();
	}

    private void HandleFiring()
    {
        if (!levelManager.AreShotsLeft()) { return; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = 0.0f;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && (timer > minFireHoldTime))
        {
            MakeShot();
            timer = 0.0f;
        }
    }

    private void MakeShot()
    {
        float launchStrength = GetLaunchStrength();
        Vector3 launchDirection = this.transform.rotation * Vector3.up;

        int newBullet = GetNextShotIndex();
        if (newBullet < 0 || newBullet > bullets.Length) { return; }

        EnableGameObject(bullets[newBullet]);
        bullets[newBullet].transform.position = GetLaunchPos();
        Rigidbody rb = bullets[newBullet].GetComponent<Rigidbody>();
        LevelManager.ResetShotCompletely(bullets[newBullet]);

        rb.AddForce(launchDirection * launchStrength * LaunchForceStrength);
        levelManager.OnFireShot();
    }

    private int GetNextShotIndex()
    {
        for (int i = 0; i < bullets.Length; ++i)
        {
            if (!bullets[i].GetComponent<DisableWhenBelow>().Gone() && !bullets[i].active) { return i; }
        }

        return -1;
    }

    public Vector3 GetLaunchPos()
    {
        Vector3 launchDirection = this.transform.rotation * Vector3.up;
        return transform.position + launchDirection * OffsetInLaunchDir;
    }


    public float GetLaunchStrength()
    {
        return Mathf.Clamp(timer / maxPowerHoldTime, 0.0f, 1.0f);
    }

    private void UpdateRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        totalRotationX = Mathf.Clamp(totalRotationX + vertical * VerticalRotateSpeed, minRotationY, maxRotationY);
        totalRotationY = Mathf.Clamp(totalRotationY + horizontal * HorizontalRotateSpeed, minRotationX, maxRotationX);

        Vector3 rotation = new Vector3(totalRotationX, totalRotationY, 0.0f);
        this.transform.rotation = Quaternion.Euler(rotation);
    }

    private void EnableGameObject(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
        objectToEnable.GetComponent<Renderer>().enabled = true;
    }

}
