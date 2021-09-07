using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, ISceneController
{
    public const int MAIN_MENU = 0;
    public const int GAME = 1;
    public void GoInGame()
    {
        SceneManager.LoadScene(GAME);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
