using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ResetMeIfNotMoving : MonoBehaviour {
    public LevelManager levelManager;
    public float threshold = 0.1f;
    public float thresholdTime = 3.0f; // if magnitude of velocity is less than threshold for time time, get rid of the thing
    private Rigidbody rb;
    private float timer;
    private bool alreadyReset = false;

    void Start()
    {
        timer = 0.0f;
        rb = GetComponent<Rigidbody>();
    }

    public void ResetReset()
    {
        timer = 0.0f;
        alreadyReset = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if (rb.velocity.magnitude < threshold) { timer += Time.deltaTime; }
        else { timer = 0.0f; }

        if (!alreadyReset && timer > thresholdTime)
        {
            alreadyReset = true;
            levelManager.ResetShot(gameObject);
        }
	}
}
