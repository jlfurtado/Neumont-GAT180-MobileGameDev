using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour {

    public float forceStrength = 10.0f;

	// Update is called once per frame
	void FixedUpdate () {
   
        // check if the mouse is clicked
		if (Input.GetMouseButtonDown(0))
        {
            // get the mouse position
            Vector3 mousePos = Input.mousePosition;

            // create the ray to cast from the mouse position
            Ray rayToCast = Camera.main.ScreenPointToRay(mousePos);

            // draw the ray
            Debug.DrawRay(rayToCast.origin, rayToCast.direction, Color.magenta, 1.0f);

            // test for raycast from the mouse position, storing the result in hit
            RaycastHit hit;
            if (Physics.Raycast(rayToCast, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                hitObject.GetComponent<Renderer>().material.color = Color.red;
                hitObject.GetComponent<Rigidbody>().AddForceAtPosition(rayToCast.direction * forceStrength, hit.point);

                Debug.Log("Hit something!");
            }
        }
	}
}
