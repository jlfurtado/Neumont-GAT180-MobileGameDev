using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour {

    #region Data

    public GameObject ballToDrop;
    public Rigidbody ballRigidBody;

    #endregion

    #region MouseClick

    // called when the mouse is released on the object
    void OnMouseUpAsButton()
    {
        // get the mouse position
        Vector3 mousePos = Input.mousePosition;

        // test for raycast from the mouse position, storing the result in hit
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out hit))
        {
            // move the ball to the position of intersection
            ballToDrop.transform.position = hit.point;

            // prevent the ball from accelerating downward faster on subsequent placements
            ballRigidBody.velocity = Vector3.zero;
        }
    }

    #endregion
}
