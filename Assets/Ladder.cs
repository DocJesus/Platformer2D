using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private MovePlayer playerMove;
    public BoxCollider2D boxCollider;

    private void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isClimbing && Input.GetButtonDown("Jump"))
        {
            playerMove.isClimbing = false;
            boxCollider.isTrigger = false;
            return;
        }

        if (isInRange && Input.GetAxis("Vertical") != 0)
        {
            playerMove.isClimbing = true;
            boxCollider.isTrigger = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMove.isClimbing = false;
            boxCollider.isTrigger = false;
        }
    }
}
