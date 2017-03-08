using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour {
    public float minFov = 15.0f;
    public float maxFov = 90.0f;
    public float sensitivity = -10.0f;
	
	// Update is called once per frame
	void Update () {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
