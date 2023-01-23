using UnityEngine;

public class RatStats : MonoBehaviour
{
    public Animator animator;
    public int startHealth = 5;
    private int currentHealth;
    public GameObject punch;
    void Start()
    {
        currentHealth = startHealth;
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <0)
        {
            currentHealth = 0;
            animator.SetTrigger("isDead");
            Destroy(gameObject, 1);
        }
        else
        {
            animator.SetTrigger("isDamage");
            Debug.Log("Fare Hasar Aldý" + currentHealth +"/"+startHealth);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("isWakingUp");
        }
        if (collision.CompareTag("Punch")){
            Hit(2);
        }
    }
}
