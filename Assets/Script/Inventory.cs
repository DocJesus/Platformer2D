using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Text coinCountText;

    public int coinsCountLevel = 0;
    public int coinsCount = 0;

    private void Awake()
    {
        coinCountText.text = coinsCount.ToString();
        if (instance != null)
        {
            Debug.LogError("Double instance singleton");
            return;
        } 
        instance = this;

    }

    public void Initialize()
    {
        coinsCountLevel = 0;
    }

    public void AddCoin(int count)
    {
        coinsCountLevel += count;
        coinsCount += count;
        coinCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCountLevel -= count;
        coinsCount -= count;
        coinCountText.text = coinsCount.ToString();
    }
}
