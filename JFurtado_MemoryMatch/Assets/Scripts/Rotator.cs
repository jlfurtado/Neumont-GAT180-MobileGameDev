using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float RotationSpeed = 0.0f;

	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.forward, RotationSpeed * Time.deltaTime);
	}
}
