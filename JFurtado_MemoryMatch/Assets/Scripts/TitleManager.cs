using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public void GoToGameScene()
    {
        SceneManager.LoadScene(Strings.GameSceneName);
    }
}