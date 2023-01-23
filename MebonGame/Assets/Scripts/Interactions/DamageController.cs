using System.Collections;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public GameObject bubbles, empty;
    private PlayerStats pStats = PlayerStats.CreateObject();
    private bool isWater, isSpike, isRat, isStartDamage = true;
    private float timer = 0, startTimer = 0, colorTimer = 0, retakeDamageTime = 1f;

    private void FixedUpdate()
    {
        if (isWater) Damage(startTime : 2f, startDamage : 0f, damagePerTime: 0.5f, damage: -0.5f, color: Color.red, peffect: bubbles) ;
        if (isSpike) Damage(startTime : 0f, startDamage : -2f, damagePerTime: 2f, damage: - 1f, color: Color.red, peffect : empty);
        if (isRat)   Damage(startTime: 0f, startDamage: 0f, damagePerTime: 0f, damage: -1f, color: Color.red, peffect: empty);
    }
    public void Damage(float startTime, float startDamage, float damagePerTime, float damage, Color color, GameObject peffect)
    {
        startTimer += Time.deltaTime;
        if (startTimer > startTime)
        {
            if(isWater) peffect.SetActive(true);
            if(isStartDamage == true && pStats.GetHeartScore() > 0)
            {
                pStats.ChangeHeartScore(startDamage);
                isStartDamage = false;
            }
            timer += Time.deltaTime;
            if (timer > damagePerTime)
            {
                if ((int)pStats.GetHeartScore() > 0) //&& pStats.GetIsItTakeDamage() == true
                {
                    GetComponent<SpriteRenderer>().color = color;
                    pStats.ChangeHeartScore(damage);
                    timer = 0;
                }
                else if((int)pStats.GetHeartScore() <= 0)
                {
                    pStats.SetIsAlive(false);
                }
            }
            colorTimer += Time.deltaTime;
            if (colorTimer > 0.3f)
            {
               GetComponent<SpriteRenderer>().color = Color.white;
               colorTimer = 0;
            }
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isWater = true;
            isStartDamage = false;
        }
        if (collision.CompareTag("RatBody"))
        {
            isRat = true;
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
        GetComponent<SpriteRenderer>().color = Color.white;
        startTimer = 0;
        timer = 0;
        if (collision.CompareTag("Water"))
        {
            isWater = false;
            bubbles.SetActive(false);
        }
        if (collision.CompareTag("RatBody"))
        {
            isRat = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            isSpike = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        startTimer = 0;
        timer = 0;
        if (collision.gameObject.tag == "Spike")
        {
            isSpike = false;
            isStartDamage = true;
        }
    }
}
