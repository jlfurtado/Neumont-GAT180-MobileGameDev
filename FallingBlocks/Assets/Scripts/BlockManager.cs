using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    #region Data

    public GameObject[] blocks;
    private BlockController[] blockControllers;
    private bool[] blockDowns;
    public float speedMultiplier = 3.5f;
    public float blockDownTime = 2.5f;
    public float blockNotifyTime = 0.25f;

    #endregion

    #region Initialization

    // Use this for initialization
    void Start()
    {
        // create arrays
        blockDowns = new bool[blocks.Length];
        blockControllers = new BlockController[blocks.Length];

        // grab components once rather than over and over
        for (int i = 0; i < blocks.Length; ++i)
        {
            blockControllers[i] = blocks[i].GetComponent<BlockController>();
        }
    }

    #endregion
    #region Block Hit Management

    // method called when a block is hit
    public void OnBlockHit(GameObject blockHit)
    {
        // find which block was hit in the array based on the passed in object - TODO: refactor to use IDS to make more performant?
        int block = GetHitBlockIndex(blockHit);

        // don't move the block if it can't be found or if it is already moving down
        if (block < 0 || blockDowns[block]) return;

        // call the method to handle the movement of the block
        StartCoroutine(HandleBlockHit(block));
    }

    // handles block movement and notifies adjacent blocks to handle their movements as well
    private IEnumerator HandleBlockHit(int block)
    {
        // begin moving the block down
        StartBlockDown(block);

        // wait before notifying the other blocks
        yield return new WaitForSeconds(blockNotifyTime);

        // notify the adjacent blocks to move themselves down
        if (block > 0 && !blockDowns[block - 1]) { StartCoroutine(HandleBlockHit(block - 1)); }
        if (block < blocks.Length - 1 && !blockDowns[block + 1]) { StartCoroutine(HandleBlockHit(block + 1)); }

        // wait to go down
        yield return new WaitForSeconds(blockDownTime);

        // change directions
        TurnBlockAround(block);

        // wait the same amount of time going up as going down
        yield return new WaitForSeconds(blockDownTime + blockNotifyTime);

        // stop the block at its original position
        StopBlock(block);
    }

    #endregion

    #region Helper Methods

    // iterates through the blocks to find a match so we can use it in the array
    private int GetHitBlockIndex(GameObject blockHit)
    {
        for (int i = 0; i < blocks.Length; ++i)
        {
            if (blockHit == blocks[i]) return i;
        }

        return -1;
    }

    // negates the y component of the velocity of block at index block
    private void TurnBlockAround(int block)
    {
        blockControllers[block].velocity *= -1.0f;
    }

    // ceases movement and adjust position for block at index block
    private void StopBlock(int block)
    {
        blockDowns[block] = false;
        blockControllers[block].velocity = Vector3.zero;
        blocks[block].transform.position = new Vector3(blocks[block].transform.position.x, 0.0f, blocks[block].transform.position.z);
    }

    // initiates downward movement for block at index block
    private void StartBlockDown(int block)
    {
        blockDowns[block] = true;
        blocks[block].GetComponent<BlockController>().velocity = speedMultiplier * Vector3.down;
    }

    #endregion
}
