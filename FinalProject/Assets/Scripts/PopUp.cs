using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour {
    public float height = 5.0f;
    public float startTime = 0.1f;
    public float life = 1.0f;
    private float timer = 0.0f;
    private float baseHeight;

	// Use this for initialization
	void Start ()
    {
        baseHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float lifeEnd = startTime + life;

        timer += Time.deltaTime;
        if (timer > startTime)
        {
            float mid = startTime + life / 2.0f;
            float cHeightOffset = Mathf.Lerp(0.0f, height, (timer < mid) ? (timer - startTime) / (mid - startTime) : (lifeEnd - timer) / (lifeEnd - mid));
            transform.position = new Vector3(transform.position.x, baseHeight + cHeightOffset, transform.position.z);
        }

        if (timer > lifeEnd)
        {
            timer = 0.0f;
            transform.position = new Vector3(transform.position.x, baseHeight, transform.position.z);
        }       
	}
}
