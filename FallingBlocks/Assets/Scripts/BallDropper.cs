using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour {
    public GameObject ballToDrop;
    public Rigidbody ballRigidBody;

    void OnMouseUpAsButton()
    {
        Vector3 mousePos = Input.mousePosition;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out hit))
        {
            ballToDrop.transform.position = hit.point;
            ballRigidBody.velocity = Vector3.zero;
        }
    }
}
