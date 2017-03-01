using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyWhenDestroyed : MonoBehaviour {
    public LevelManager levelManager;

    public void GoPoof()
    {
        levelManager.OnProjectileDestroyed();
    }
}
