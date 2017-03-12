using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ResetMeIfNotMoving : MonoBehaviour {
    public LevelManager levelManager;
    public float threshold = 0.1f;
    public float thresholdTime = 3.0f; // if magnitude of velocity is less than threshold for time time, get rid of the thing
    public Color lerpToColor = Color.yellow;
    public GameObject particles;
    private Color baseColor;
    private Rigidbody rb;
    private float timer;
    private float pTimer;
    private bool alreadyReset = false;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
        timer = 0.0f;
        rb = GetComponent<Rigidbody>();
    }

    public void ResetReset()
    {
        timer = 0.0f;
        alreadyReset = false;
    }

    private void EnableGameObject(GameObject objectToEnable)
    {
        objectToEnable.SetActive(true);
        objectToEnable.GetComponent<Renderer>().enabled = true;
        objectToEnable.transform.position = transform.position;
    }

    private void DisableGameObject(GameObject objectToEnable)
    {
        objectToEnable.SetActive(false);
        objectToEnable.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
        pTimer += Time.deltaTime;

        if (rb.velocity.magnitude < threshold) { timer += Time.deltaTime; }
        else { timer = 0.0f;  }

        rend.material.color = Color.Lerp(baseColor, lerpToColor, timer / thresholdTime);

        if (pTimer > particles.GetComponent<ParticleSystem>().main.duration) { DisableGameObject(particles); }

        if (!alreadyReset && timer > thresholdTime)
        {
            alreadyReset = true;
            EnableGameObject(particles);
            levelManager.ResetShot(gameObject);
            pTimer = 0.0f;
        }
    }
}
