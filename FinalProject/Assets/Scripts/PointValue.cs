using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointValue : MonoBehaviour {
    public int pointValue = 10;
    public ScoreManager scoreManagerRef;


    public void AssignScore()
    {
        scoreManagerRef.AddScore(pointValue);
    }


}
