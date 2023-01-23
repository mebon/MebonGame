using TMPro;
using UnityEngine;

public class CoinScoreController : MonoBehaviour
{
    public TextMeshProUGUI playerCoinText;
    private PlayerStats playerStats = PlayerStats.CreateObject();

    public int coin;
    // Update is called once per frame
    void Update()
    {
        coin = playerStats.GetCoinScore();
        playerCoinText.text = coin.ToString();
    }
}
