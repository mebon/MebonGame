using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletLocation;
    private float punchSpeed, punchTimer, powerTimer, maxPower, currentPower, minPower;
    [Header("Punch Damage On Hit")]
    public int damage;
    private PlayerStats pStats = PlayerStats.CreateObject();
    private bool left = false, right = true;
    void Start()
    {
        punchSpeed = 300f;
        maxPower = pStats.GetPowerScore();
        minPower = 0f;
    }

    void Update()
    {
        currentPower = pStats.GetPowerScore();
        if(currentPower > minPower)
        {
            SetAttackRotation();
            punchTimer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (punchTimer <= 0)
                {
                    if(currentPower>4.8f) Punch();
                    punchTimer = 0.25f;
                }
            }
        }
        ReloadPower(time: 0.1f, power: 0.2f);
    }
    private void SetAttackRotation()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            left = true; right = false;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            left = false; right = true;
        }
    }
    private void Punch()
    {
        GameObject bllt = Instantiate(bullet, bulletLocation.position, bulletLocation.rotation);
        if (left)
        {
            bllt.GetComponent<Rigidbody2D>().velocity = new Vector2(punchSpeed * Time.fixedDeltaTime * -1, 0);
        }
        if (right)
        {
            bllt.GetComponent<Rigidbody2D>().velocity = new Vector2(punchSpeed * Time.fixedDeltaTime, 0);
        }
        pStats.ChangePowerScore(-10f);
    }
    void ReloadPower(float time, float power)
    {
        if (currentPower < maxPower)
        {
            powerTimer += Time.deltaTime;
            if (powerTimer >= time)
            {
                pStats.ChangePowerScore(power);
                powerTimer = 0;
            }
        }
    }
}
