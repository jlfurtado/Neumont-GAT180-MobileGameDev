using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void GoToVictoryScene()
    {
        SceneManager.LoadScene(Strings.VictorySceneName);
    }

    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(Strings.GameOverSceneName);
    }

}
