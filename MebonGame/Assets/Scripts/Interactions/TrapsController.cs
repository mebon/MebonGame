using UnityEngine;

public class TrapsController : MonoBehaviour
{
    private PlayerStats pStats = PlayerStats.CreateObject();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pStats = collision.gameObject.GetComponent<PlayerStats>();
            if ((int)pStats.GetHeartScore() > 0)
            {
                pStats.ChangeHeartScore(-0.5f);
            }
            else
            {
                pStats.SetIsAlive(false);
            }
            

        }
    }
}
