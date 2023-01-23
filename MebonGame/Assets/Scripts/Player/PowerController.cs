using TMPro;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    private PlayerStats playerStats = PlayerStats.CreateObject();
    public TextMeshProUGUI playerCurrentPowerText, playerMaxPowerText;
    private float playerMaxPower;
    public PowerBar powerBar;
    void Start()
    {
        powerBar.SetMaxPower(playerStats.GetPowerScore());
        playerMaxPower = playerStats.GetPowerScore();
        playerMaxPowerText.text = "/" + playerMaxPower.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.GetPowerScore() < 0)
        {
            playerCurrentPowerText.text = "0";
        }
        else
        {
            playerCurrentPowerText.text = ((int)playerStats.GetPowerScore()).ToString();
            powerBar.SetPower(playerStats.GetPowerScore());
        }
    }
}
