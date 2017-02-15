using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public float BaseRotationSpeed;

    private float rotation = 0.0f;
    private float rotationSpeed = 0.0f;
    private const float rotationThreshold = 3.141592654f;
    private bool isRotating = false; // TODO: MANAGER!?!?!?

	// Update is called once per frame
	void Update () {
        float rotateAmount = rotationSpeed * Time.deltaTime;
        transform.RotateAround(Vector3.up, rotateAmount);
        rotation += rotateAmount;

        if (rotation > rotationThreshold)
        {
            stopRotate();
        }
	}

    void OnMouseDown()
    {
        startRotate();
    }

    private void startRotate()
    {
        if (!isRotating)
        {
            rotationSpeed = BaseRotationSpeed;
            isRotating = true;
        }
    }

    private void stopRotate()
    {
        rotationSpeed = 0.0f;
        rotation = 0.0f;
        isRotating = false;
    }
}
