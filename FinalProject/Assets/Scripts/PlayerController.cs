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
            DisableGameObject(bullets[i]);
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
        Vector3 launchPos = transform.position + launchDirection * OffsetInLaunchDir;

        int newBullet = levelManager.GetNextShotIndex();
        EnableGameObject(bullets[newBullet]);
        bullets[newBullet].transform.position = launchPos;

        Rigidbody rb = bullets[newBullet].GetComponent<Rigidbody>();
        StopRB(rb);

        rb.AddForce(launchDirection * launchStrength * LaunchForceStrength);
        levelManager.OnFireShot();
    }

    private void StopRB(Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
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

    private void DisableGameObject(GameObject objectToDisable)
    {
        objectToDisable.SetActive(false);
        objectToDisable.GetComponent<Renderer>().enabled = false;
    }
}
