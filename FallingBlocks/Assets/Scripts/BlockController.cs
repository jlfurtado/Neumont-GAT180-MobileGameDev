using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public Vector3 velocity;
    private BlockManager blockManager;

	// Use this for initialization
	void Start () {
        blockManager = gameObject.transform.parent.gameObject.GetComponent<BlockManager>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Time.deltaTime * velocity;
	}

    void OnCollisionEnter()
    {
        blockManager.OnBlockHit(gameObject);
    }
}
