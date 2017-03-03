using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractFromRequiredCounter : MonoBehaviour {
    public LevelManager levelManager;

	public void MeIsGone()
    {
        levelManager.OnRequiredObjectDestroyed();
    }
}
