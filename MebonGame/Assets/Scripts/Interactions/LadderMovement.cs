using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    private PlayerStats playerStats = PlayerStats.CreateObject();
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            playerStats.GetRB().gravityScale = 0f;
            playerStats.GetRB().velocity = new Vector2(playerStats.GetRB().velocity.x, vertical * playerStats.GetSpeedAmount()*2); //rb.velocity = new Vector2(rb.velocity.x, speed); yükselme
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            playerStats.GetRB().gravityScale = 2f;
        }
    }
}