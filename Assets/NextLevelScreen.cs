using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelScreen : MonoBehaviour
{
    public Text lostedHeart;
    public Text gainedCoin;
    public Text congrats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateStats()
    {
        congrats.text = "You Finished " + SceneManager.GetActiveScene().name;
        lostedHeart.text = "You have " + PlayerHealth.instance.currentHealth;
        gainedCoin.text = "You gained " + Inventory.instance.coinsCountLevel;
    }
}
