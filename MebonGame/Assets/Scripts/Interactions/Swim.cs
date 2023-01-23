using UnityEngine;

public class Swim : MonoBehaviour
{
    public Animator animator;
    private float vertical;
    private bool isWater;
    private bool isSwimming;
    private PlayerStats playerStats = PlayerStats.CreateObject();

    void Update()
    {

        vertical = Input.GetAxisRaw("Vertical");

        if (isWater)
        {
            isSwimming = true;
        }
    }

    private void FixedUpdate()
    {
        if (isSwimming)
        {
            playerStats.GetRB().gravityScale = 1f;
            playerStats.GetRB().velocity = new Vector2(playerStats.GetRB().velocity.x, vertical * playerStats.GetSpeedAmount());
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isWater = false;
            isSwimming = false;
            playerStats.GetRB().gravityScale = 2f;
        }
    }
}