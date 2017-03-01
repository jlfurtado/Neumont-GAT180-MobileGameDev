using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenBelow : MonoBehaviour {

    public float YDestroyThreshold = 0.0f;
    private bool isMeGone = false;
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < YDestroyThreshold && !isMeGone)
        {
            GetRidOfMe();
            isMeGone = true;
        }
    }

    private void GetRidOfMe()
    {
        DoGiveScoreForThisIfShould();
        DoNotifyDestroyIfShould();

        gameObject.SetActive(false);
        gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(gameObject);
    }

    private void DoGiveScoreForThisIfShould()
    {
        PointValue pv = GetComponent<PointValue>();
        if (pv != null) { pv.AssignScore(); }
    }

    private void DoNotifyDestroyIfShould()
    {
        NotifyWhenDestroyed nf = GetComponent<NotifyWhenDestroyed>();
        if (nf != null) { nf.GoPoof(); }
    }

}
