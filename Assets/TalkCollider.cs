using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCollider : MonoBehaviour
{
    [SerializeField]
    private string message;
    private bool isReading = false;

    private void Update()
    {
        
        if (isReading && Input.GetKeyDown(KeyCode.Space))
        {
            TalkBox.instance.WipeText();
            isReading = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("bite");
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("bite2");

            isReading = true;
            TalkBox.instance.WriteText(message);
        }
    }
}
