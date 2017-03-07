using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cannonball : MonoBehaviour {
    public Vector3 forceToDo;
    public float lifeTime = 5.0f;
    public float maxVariationStartOffsets = 2.0f;
    private float timer = 0.0f;
    private Rigidbody rb;
    private Vector3 basePos;
    private bool first = true;
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        basePos = transform.position + RandBetween(-maxVariationStartOffsets, maxVariationStartOffsets);
        startTime = Random.Range(0.0f, lifeTime);
    }

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > startTime && first)
        {
            first = false;
            timer -= startTime;
            StartBall();
        }

        if ((timer > lifeTime && !first))
        {
            StartBall();
        }
         
	}

    private void StartBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        timer = 0.0f;
        transform.position = basePos;
        rb.AddForce(forceToDo);
    }
    
    private Vector3 RandBetween(float min, float max)
    {
        return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }
}
