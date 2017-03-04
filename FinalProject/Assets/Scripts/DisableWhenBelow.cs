using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWhenBelow : MonoBehaviour {

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
    public void Reset()
    {
        isMeGone = false;
    }

    private void GetRidOfMe()
    {
        DoGiveScoreForThisIfShould();
        DoNotifyDestroyIfShould();
        DoSubtractRequiredIfShould();

        gameObject.SetActive(false);
        gameObject.GetComponent<Renderer>().enabled = false;
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

    private void DoSubtractRequiredIfShould()
    {
        SubtractFromRequiredCounter sfr = GetComponent<SubtractFromRequiredCounter>();
        if (sfr != null) { sfr.MeIsGone(); }
    }
}
