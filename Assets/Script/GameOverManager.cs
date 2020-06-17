using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject deathUI;
    public PauseMenu pauseMenu;
    private Animator fadeSystem;


    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();

        if (instance != null)
        {
            Debug.LogError("Double instance singleton");
            return;
        }
        instance = this;

    }

    // à changer pour l'activer sur le bouton échape
    public void OnPlayerDeath()
    {
        deathUI.SetActive(true);
        pauseMenu.enabled = false;
    }

    public void Retry()
    {
        StartCoroutine(loadRetry());
    }

    public IEnumerator loadRetry()
    {
        fadeSystem.SetTrigger("FadeIn");
        MovePlayer.instance.DesactivatePlayer();
        yield return new WaitForSeconds(0.5f);
        fadeSystem.SetTrigger("FadeOut");

        PlayerHealth.instance.Respawn();
        //vérifie si le joueur est résent par défaut dans la scene
        if (CurrentSceneManager.instance.isPlayerPresentInSceneByDefault)
        {
            //retire les éléments du DontDestroyOnLoad pour éviter les duplicatas
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }
        Inventory.instance.RemoveCoins(Inventory.instance.coinsCountLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenu.enabled = true;
        deathUI.SetActive(false);
    }

    public void MainMenuButton()
    {

    }
}
