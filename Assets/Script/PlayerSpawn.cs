using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = transform.position + new Vector3(0, 1, 0);
    }
}
