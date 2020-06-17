using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        if (collision.CompareTag("Ennemy"))
        {
            transform.parent.GetComponent<MovePlayer>().Jump();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ladder"))
            isGrounded = false;
    }
}
