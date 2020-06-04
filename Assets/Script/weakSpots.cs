using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakSpots : MonoBehaviour
{
    public GameObject objToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnnemyKiller"))
        {
            Destroy(objToDestroy);
        }
    }
}
