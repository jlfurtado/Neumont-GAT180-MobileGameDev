using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenBelow : MonoBehaviour {

    public float YDestroyThreshold = 0.0f;
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < YDestroyThreshold)
        {
            GetRidOfMe();
        }
    }

    private void GetRidOfMe()
    {
        DoGiveScoreForThisIfShould();

        gameObject.SetActive(false);
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject);
    }

    private void DoGiveScoreForThisIfShould()
    {
        PointValue pv = GetComponent<PointValue>();
        if (pv != null) { pv.AssignScore(); }
    }

}
