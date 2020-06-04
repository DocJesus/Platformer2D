using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MovePlayerOnSpawn(collision.transform));
        }
    }

    public IEnumerator MovePlayerOnSpawn(Transform _playerTrans)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        fadeSystem.SetTrigger("FadeOut");
        _playerTrans.position = playerSpawn.position;
        yield return new WaitForSeconds(0.5f);
    }
}
