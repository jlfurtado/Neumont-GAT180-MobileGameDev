using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMover : MonoBehaviour {

	public void MoveToLevelOne()
    {
        SceneManager.LoadScene(Strings.LEVEL_ONE_SCENE_NAME);
    }
}
