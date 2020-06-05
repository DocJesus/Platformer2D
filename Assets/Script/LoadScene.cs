using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;
    private Animator endLevelScreen;
    private NextLevelScreen nextLevelScreen;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();

        GameObject toto = GameObject.FindGameObjectWithTag("NextLevelScreen");
        endLevelScreen = toto.GetComponent<Animator>();
        nextLevelScreen = toto.GetComponent<NextLevelScreen>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nextLevelScreen.UpdateStats();
            StartCoroutine(loadNextScene());
        }
            
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        endLevelScreen.SetTrigger("FadeIn");
        MovePlayer.instance.DesactivatePlayer();
        yield return new WaitForSeconds(0.5f);
 
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return new WaitForSeconds(0.01f);
        }

        fadeSystem.SetTrigger("FadeOut");
        endLevelScreen.SetTrigger("FadeOut");
        MovePlayer.instance.ActivatePlayer();
        SceneManager.LoadScene(sceneName);
    }
}
