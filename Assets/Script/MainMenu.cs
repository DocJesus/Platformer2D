using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToload; // Level01

    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
    }

    public void Settings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
