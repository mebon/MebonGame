using System.Collections;
using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject deathFlag, screenEffect;
    public TextMeshProUGUI playerHeartText, playerMaxHealthText;
    private float playerMaxHealth;
    private PlayerStats playerStats = PlayerStats.CreateObject();
    public HealthBar healthBar;

    public bool isAlive;
    // Update is called once per frame
    void Start()
    {
        healthBar.SetMaxHealth(playerStats.GetHeartScore());
        playerMaxHealth = playerStats.GetHeartScore();
        playerMaxHealthText.text = "/" + playerMaxHealth.ToString();

    }
    void Update()
    {
        isAlive = playerStats.GetIsAlive();
        if (isAlive == true)
        {
            playerHeartText.text = (playerStats.GetHeartScore()).ToString();
                                 //((int)playerStats.GetHeartScore()).ToString();
            healthBar.SetHealth(playerStats.GetHeartScore());
        }
        else
        {
            playerHeartText.text = "0";
            StartCoroutine(delayactiv());
        }
        IEnumerator delayactiv()
        {
            yield return new WaitForSeconds(2);
            deathFlag.SetActive(true);
            screenEffect.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
