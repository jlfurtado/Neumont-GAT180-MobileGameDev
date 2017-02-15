using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public float BaseRotationSpeed;
    public int ImageIndex;
    private float rotation = 0.0f;
    private float rotationSpeed = 0.0f;
    private float rotationThreshold = Mathf.PI;
    public bool isRotating = false;
    private CardGameManager cgm;
    private SpriteRenderer sr;
    private Sprite nextSprite;
    private Vector3 currentAxis;
    private bool shouldDie;
    private bool initialAnimation;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cgm = transform.parent.gameObject.GetComponent<CardGameManager>();
        shouldDie = false;
        initialAnimation = true;
    }

    // Update is called once per frame
    void Update () {
        float rotateAmount = rotationSpeed * Time.deltaTime;
        transform.RotateAround(currentAxis, rotateAmount);
        rotation += rotateAmount;

        if (nextSprite != null && rotation > 0.5f * rotationThreshold)
        {
            sr.sprite = nextSprite;
            nextSprite = null;
        }

        if (rotation > rotationThreshold)
        {
            stopRotate();
            if (initialAnimation) { StartFlip(transform.parent.gameObject.GetComponent<CardGameManager>().cardBackImage); initialAnimation = false; }
            else if (shouldDie)
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

    public void StartFlip(Sprite nextSprite)
    {
        this.nextSprite = nextSprite;
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
