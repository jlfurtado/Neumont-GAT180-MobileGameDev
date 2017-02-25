using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevelSelectScene : MonoBehaviour {

    public void MoveToLevelSelect()
    {
        SceneManager.LoadScene(Strings.LEVEL_SELECT_SCENE_NAME);
    }
}
