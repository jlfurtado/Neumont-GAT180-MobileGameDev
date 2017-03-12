using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour {

    public void MoveToTitle()
    {
        KeepTitleMusic();
        SceneManager.LoadScene(Strings.TITLE_SCENE_NAME);
    }

    public void MoveToVictory()
    {
        DontKeepTitleMusic();
        SceneManager.LoadScene(Strings.LEVEL_WON_SCENE_NAME);
    }

    public void MoveToLoss()
    {
        DontKeepTitleMusic();
        SceneManager.LoadScene(Strings.LEVEL_LOST_SCENE_NAME);
    }

    public void MoveToLevelSelect()
    {
        KeepTitleMusic();
        SceneManager.LoadScene(Strings.LEVEL_SELECT_SCENE_NAME);
    }

    public void MoveToOptions()
    {
        KeepTitleMusic();
        SceneManager.LoadScene(Strings.OPTIONS_SCENE_NAME);
    }

    public void MoveToLevelOne()
    {
        DontKeepTitleMusic();
        SceneManager.LoadScene(Strings.LEVEL_ONE_SCENE_NAME);
    }


    public void MoveToLevelTwo()
    {
        DontKeepTitleMusic();
        SceneManager.LoadScene(Strings.LEVEL_TWO_SCENE_NAME);
    }


    public void MoveToLevelThree()
    {
        DontKeepTitleMusic();
        SceneManager.LoadScene(Strings.LEVEL_THREE_SCENE_NAME);
    }

    public void MoveToLevelFour()
    {
        DontKeepTitleMusic();
        SceneManager.LoadScene(Strings.LEVEL_FOUR_SCENE_NAME);
    }

    public void MoveToHowToPlay()
    {
        KeepTitleMusic();
        SceneManager.LoadScene(Strings.HOW_TO_PLAY_SCENE_NAME);
    }

    private void KeepTitleMusic()
    {
        GameObject titleMusic = GameObject.FindGameObjectWithTag(Strings.TITLE_MUSIC_TAG);
        if (titleMusic != null) { DontDestroyOnLoad(titleMusic); }
    }

    private void DontKeepTitleMusic()
    {
        GameObject titleMusic = GameObject.FindGameObjectWithTag(Strings.TITLE_MUSIC_TAG);
        if (titleMusic != null) { Destroy(titleMusic); }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
