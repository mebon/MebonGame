using UnityEngine;
[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    private static Rigidbody2D rb;
    public static float speedAmount;
    public static float jumpAmount;
    public static int coinScore;
    public static float heartScore;
    public static float powerScore;
    public static bool isAlive;
    public static bool isItTakeDamage;
    
    private static PlayerStats mp_Ps;
    public void Start()
    {
        isAlive = true;
        coinScore = 0;
        heartScore = 10f;
        powerScore = 100f;
        speedAmount = 1.5f;
        jumpAmount = 5f;
        isItTakeDamage = true;
    }
    protected PlayerStats()
    {
        isAlive = true;
        coinScore = 0;
        heartScore = 10;
        powerScore = 100f;
        powerScore = Mathf.Clamp(powerScore, 0f, 100f);
        speedAmount = 1.5f;
        jumpAmount = 5f;
        isItTakeDamage = true;
    }
    public static PlayerStats CreateObject()
    {
        if(mp_Ps == null)
        {
            mp_Ps = new PlayerStats();
        }
        return mp_Ps;
    }
    public Rigidbody2D GetRB()
    {
        return rb;
    }
    public void SetRB(Rigidbody2D val)
    {
        rb = val;
    }
    public float GetSpeedAmount()
    {
        return speedAmount;
    }
    public void SetSpeedAmaount(float val)
    {
        speedAmount = val;
    }
    public float GetJumpAmount()
    {
        return jumpAmount;
    }
    public void SetJumpAmount(float val)
    {
        jumpAmount = val;
    }
    public int GetCoinScore()
    {
        return coinScore;
    }
    public void SetCoinScore(int val)
    {
        coinScore = val;
    }
    public void ChangeCoinScore(int val)
    {
        coinScore += val;
    }
    public float GetHeartScore()
    {
        return heartScore;
    }
    public void SetHeartScore(float val)
    {
        heartScore = val;
    }
    public void ChangeHeartScore(float val)
    {
        heartScore += val;
    }
    public float GetPowerScore()
    {
        return powerScore;
    }
    public void SetPowerScore(float val)
    {
        powerScore = val;
    }
    public void ChangePowerScore(float val)
    {
        powerScore += val;
    }
    public bool GetIsAlive()
    {
        return isAlive;
    }
    public void SetIsAlive(bool val)
    {
        isAlive = val;
    }
    public bool GetIsItTakeDamage()
    {
        return isItTakeDamage;
    }
    public void SetIsItTakeDamage(bool val)
    {
        isItTakeDamage = val;
    }
}
