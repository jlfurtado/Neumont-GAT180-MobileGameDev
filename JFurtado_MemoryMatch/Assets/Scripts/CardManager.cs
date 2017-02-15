using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public float BaseRotationSpeed;
    public int ImageIndex;
    private float rotation = 0.0f;
    private float rotationSpeed = 0.0f;
    private float rotationThreshold = Mathf.PI;
    private bool isRotating = false; // TODO: MANAGER!?!?!?
    private CardGameManager cgm;
    private Vector3 currentAxis;
    private bool shouldDie;

    void Start()
    {
        cgm = transform.parent.gameObject.GetComponent<CardGameManager>();
        shouldDie = false;
    }

    // Update is called once per frame
    void Update () {
        float rotateAmount = rotationSpeed * Time.deltaTime;
        transform.RotateAround(currentAxis, rotateAmount);
        rotation += rotateAmount;

        if (rotation > rotationThreshold)
        {
            stopRotate();

            if (shouldDie)
            {
                this.GetComponent<Renderer>().enabled = false;
                this.enabled = false;
            }
        }
	}

    void OnMouseDown()
    {
        if (!isRotating && !cgm.IsCardRotating)
        {
            cgm.OnCardClicked(this);
        }
    }

    public void OnMatched()
    {
        shouldDie = true;
        startRotate(Vector3.forward, 3.0f*Mathf.PI);
    }

    public void StartFlip()
    {
        startRotate(Vector3.up, Mathf.PI);
    }

    private void startRotate(Vector3 axis, float threshold)
    {
        rotationSpeed = BaseRotationSpeed;
        isRotating = true;
        currentAxis = axis;
        rotationThreshold = threshold;
    }

    private void stopRotate()
    {
        rotationSpeed = 0.0f;
        rotation = 0.0f;
        isRotating = false;
        cgm.OnCardFlipEnd();
    }
}
