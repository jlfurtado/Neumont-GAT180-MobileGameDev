using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointValue : MonoBehaviour {
    public long pointValue = 10L;
    public ScoreManager scoreManagerRef;


    public void AssignScore()
    {
        scoreManagerRef.AddScore(pointValue);
    }


}
