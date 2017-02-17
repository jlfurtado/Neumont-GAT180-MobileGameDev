using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public GameObject[] blocks;
    private BlockController[] blockControllers;
    private bool[] blockDowns;
    private float blockDownThreshold = -7.5f;
    private float speedMultiplier = 3.5f;

    // Use this for initialization
    void Start()
    {
        blockDowns = new bool[blocks.Length];
        blockControllers = new BlockController[blocks.Length];

        for (int i = 0; i < blocks.Length; ++i)
        {
            blockControllers[i] = blocks[i].GetComponent<BlockController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < blocks.Length; ++i)
        {
            if (blockDowns[i] && blockControllers[i].velocity.y < 0.0f && blocks[i].transform.position.y < blockDownThreshold)
            {
                TurnBlockAround(i);
            }
            else if (blockControllers[i].velocity.y > 0.0f && blocks[i].transform.position.y > 0.0f)
            {
                StopBlock(i);
            }
        }
    }

    private void TurnBlockAround(int block)
    {
        blockControllers[block].velocity *= -1.0f;
    }

    private void StopBlock(int block)
    {
        blockDowns[block] = false;
        blockControllers[block].velocity = Vector3.zero;
        blocks[block].transform.position = new  Vector3(blocks[block].transform.position.x, 0.0f, blocks[block].transform.position.z);
    }

    private void StartBlockDown(int block)
    {
        blockDowns[block] = true;
        blocks[block].GetComponent<BlockController>().velocity = speedMultiplier * Vector3.down;
    }

    public void OnBlockHit(GameObject blockHit)
    {
        int block = GetHitBlockIndex(blockHit);

        if (block < 0 || blockDowns[block]) return;

        StartCoroutine(HandleBlockHit(block));
    }

    private IEnumerator HandleBlockHit(int block)
    {
        StartBlockDown(block);

        yield return new WaitForSeconds(0.25f);

        if (block > 0 && !blockDowns[block - 1]) { StartCoroutine(HandleBlockHit(block - 1)); }
        if (block < blocks.Length - 1 && !blockDowns[block + 1]) { StartCoroutine(HandleBlockHit(block + 1)); }

    }

    private int GetHitBlockIndex(GameObject blockHit)
    {
        for (int i = 0; i < blocks.Length; ++i)
        {
            if (blockHit == blocks[i]) return i;
        }

        return -1;
    }
}
