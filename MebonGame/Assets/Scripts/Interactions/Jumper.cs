using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jumper : MonoBehaviour
{
    public Animator animator;
    private float vertical;
    private bool isJumper;
    private bool isOnJumper;
    private PlayerStats playerStats = PlayerStats.CreateObject();

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isJumper)
        {
            isOnJumper = true;
        }
    }

    private void FixedUpdate()
    {
        if (isOnJumper)
        {
            playerStats.GetRB().gravityScale = 2f;
            playerStats.GetRB().velocity = new Vector2(playerStats.GetRB().velocity.x, vertical * playerStats.GetSpeedAmount() * 2);
            playerStats.GetRB().AddForce(Vector3.up * playerStats.GetJumpAmount()/5*7, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jumper"))
        {
            isJumper = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jumper"))
        {
            isJumper = false;
            isOnJumper = false;
        }
    }
}
