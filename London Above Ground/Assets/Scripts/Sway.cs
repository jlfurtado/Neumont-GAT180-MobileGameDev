using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour {
    public float maxRotation;
    public float minRotation;
    public float rotationSpeed;
    private float rotation;
    private float sign = 1.0f;

	// Update is called once per frame
	void Update () {
        rotation += sign * rotationSpeed * Time.deltaTime;
        if (rotation > maxRotation || rotation < minRotation) { sign *= -1.0f; rotation = Mathf.Clamp(rotation, minRotation, maxRotation); }
        transform.rotation = Quaternion.Euler(new Vector3(rotation, 0.0f, 0.0f));
	}
}
