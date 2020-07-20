using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public static bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pauseUI.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
            }
            else
            {
                pauseUI.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        GameOverManager.instance.Retry();
        pauseUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuiButton()
    {
        Application.Quit();
    }
}
