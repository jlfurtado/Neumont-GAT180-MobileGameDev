using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    #region Data

    public Vector3 velocity;
    private BlockManager blockManager;

    #endregion

    #region Initialization

    // Use this for initialization
    void Start () {
        blockManager = gameObject.transform.parent.gameObject.GetComponent<BlockManager>();
	}

    #endregion

    #region Update

    // simply translate the block based on its velocity, accounting for delta time
    void Update () {
        transform.position += Time.deltaTime * velocity;
	}

    #endregion

    #region Collision

    // when the block is collided with, tell the block manager, "Hey, I was hit" so it can act accordingly
    void OnCollisionEnter()
    {
        blockManager.OnBlockHit(gameObject);
    }

    #endregion

}
