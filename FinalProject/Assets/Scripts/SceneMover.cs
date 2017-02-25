using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour {

    public void MoveToTitle()
    {
        SceneManager.LoadScene(Strings.TITLE_SCENE_NAME);
    }

    public void MoveToLevelSelect()
    {
        SceneManager.LoadScene(Strings.LEVEL_SELECT_SCENE_NAME);
    }

    public void MoveToOptions()
    {
        SceneManager.LoadScene(Strings.OPTIONS_SCENE_NAME);
    }

    public void MoveToLevelOne()
    {
        SceneManager.LoadScene(Strings.LEVEL_ONE_SCENE_NAME);
    }


    public void MoveToLevelTwo()
    {
        SceneManager.LoadScene(Strings.LEVEL_TWO_SCENE_NAME);
    }


    public void MoveToLevelThree()
    {
        SceneManager.LoadScene(Strings.LEVEL_THREE_SCENE_NAME);
    }

    public void MoveToLevelFour()
    {
        SceneManager.LoadScene(Strings.LEVEL_FOUR_SCENE_NAME);
    }
}
