using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentInSceneByDefault;

    public static CurrentSceneManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("Double instance CurrentSceneManager");
            return;
        }
        instance = this;
    }

}
