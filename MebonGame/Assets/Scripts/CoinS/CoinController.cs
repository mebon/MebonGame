using UnityEngine;

public class CoinController : MonoBehaviour
{
    private PlayerStats pStats =PlayerStats.CreateObject();
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag.Equals("Player"))
        {
            pStats = collision.gameObject.GetComponent<PlayerStats>();
            pStats.ChangeCoinScore(1);
            Destroy(gameObject);
        }
    }
}
