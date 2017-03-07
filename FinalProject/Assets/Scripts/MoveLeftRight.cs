using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveLeftRight : MonoBehaviour {
    public float speed  = 1.0f;
    public float movementAmount = 10.0f;
    private float amountMoved = 0.0f;
    private bool right = true;
    private bool first = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        float amountToMove = speed * Time.deltaTime;
        if (!right) { amountToMove *= -1.0f; }

        if (Mathf.Abs(amountMoved + amountToMove) > (first ? movementAmount : movementAmount * 2.0f)) { ChangeDirection(); }
        else { DoMovement(amountToMove); }
	}

    private void DoMovement(float amount)
    {
        amountMoved += amount;
        Vector3 moveVec = new Vector3(amount, 0.0f, 0.0f);
        transform.position += moveVec;
    }

    private void ChangeDirection()
    {
        first = false;
        right = !right;
        amountMoved = 0.0f;
    }
}
