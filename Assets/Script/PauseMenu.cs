using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    private bool isShown = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isShown)
            {
                pauseUI.SetActive(true);
                isShown = true;
            }
            else
            {
                pauseUI.SetActive(false);
                isShown = false;
            }
        }
    }

    public void Retry()
    {
        GameOverManager.instance.Retry();
        pauseUI.SetActive(false);
    }

    public void MainMenuButton()
    {

    }

    public void QuiButton()
    {
        Application.Quit();
    }
}
