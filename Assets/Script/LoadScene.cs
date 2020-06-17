using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSystem;
    private Animator nextLevelAnimator;
    private NextLevelScreen nextLevelScreen;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();

        GameObject toto = GameObject.FindGameObjectWithTag("NextLevelScreen");
        nextLevelAnimator = toto.GetComponent<Animator>();
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
        nextLevelAnimator.SetTrigger("FadeIn");
        MovePlayer.instance.DesactivatePlayer();
        yield return new WaitForSeconds(0.5f);
 
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return new WaitForSeconds(0.01f);
        }

        fadeSystem.SetTrigger("FadeOut");
        nextLevelAnimator.SetTrigger("FadeOut");
        Inventory.instance.Initialize();
        MovePlayer.instance.ActivatePlayer();
        SceneManager.LoadScene(sceneName);
    }
}
