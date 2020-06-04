using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    private string name;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (name)
            {
                case "Heart":
                    PlayerHealth.instance.Heal(10);
                    break;
                case "Coin":
                    Inventory.instance.AddCoin(1);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
