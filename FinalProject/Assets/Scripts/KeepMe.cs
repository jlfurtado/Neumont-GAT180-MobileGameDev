using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour {
    public GameObject backgroundMusicPrefab;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag(Strings.TITLE_MUSIC_TAG) == null)
        {
            Instantiate(backgroundMusicPrefab);
        }
    }
}
