using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;
    public Animator animator;
    private PlayerStats playerStats = PlayerStats.CreateObject();
    private float jumpTimeCounter = 0, jumpTime = 0.2f, dashDistance = 3f, bounceBackDistance = 4f, doubleTapTime, dashTimer = 0;
    private bool isWalking, isRunning, isCrouching, isRat = false, isDashing = false, isBouncingBack = false, isJumping, isPunching, isClimbing, isSwimming, isEnding;
    KeyCode lastKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        playerStats.SetRB(GetComponent<Rigidbody2D>());
    }
    // Update is called once per frame
    void Update()
    {
        if(playerStats.GetIsAlive() == true && Time.timeScale == 1)
        {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
            Movement();
            Turn();
            Jump();
            Punch();
            BounceBackLeft();
            BounceBackRight();
        }
        else if(playerStats.GetIsAlive() == false)
        {
            animator.SetBool("isDead", true);
        }
        else if(isRat == true)
        {
            if(lastKeyCode == KeyCode.D)
            {
                BounceBackLeft();
            }
            if (lastKeyCode == KeyCode.A)
            {
                BounceBackRight();
            }
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
            if (Input.GetKeyDown(KeyCode.D))
            {
                DashRight();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                DashLeft();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DashRight();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            DashLeft();
        }
        else
        {
            Walk();
        }
    }
    private void Walk()
    {
        transform.localScale = new Vector3(1, 1, 1);
        velocity = new Vector3(Input.GetAxis("Horizontal") * playerStats.GetSpeedAmount(), 0);
        transform.position += velocity * playerStats.GetSpeedAmount() * Time.deltaTime;
        isWalking = true;

    }
    private void Run()
    {
        transform.localScale = new Vector3(1, 1, 1);
        velocity = new Vector3(Input.GetAxis("Horizontal") * playerStats.GetSpeedAmount() / 2 * 3, 0);
        transform.position += velocity * playerStats.GetSpeedAmount() * Time.deltaTime;
        isRunning = true;
    }
    private void Crouch()
    {
        transform.localScale = new Vector3(1, 0.5f, 1);
        velocity = new Vector3(Input.GetAxis("Horizontal") * playerStats.GetSpeedAmount() / 2, 0);
        transform.position += velocity * playerStats.GetSpeedAmount() * Time.deltaTime;
        isCrouching = true;
    }
    private void DashLeft()
    {
        if(isDashing == false && doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
        {
            StartCoroutine(Dash(-1f));
        }
        else
        {
            doubleTapTime = Time.time + 0.2f;
        }
        lastKeyCode = KeyCode.A;
    }
    private void DashRight()
    {
        if (isDashing == false && doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
        {
            StartCoroutine(Dash(1f));
        }
        else
        {
            doubleTapTime = Time.time + 0.2f;
        }
        lastKeyCode = KeyCode.D;
    }
    IEnumerator Dash(float direction)
    {
        float playerSpeed = playerStats.GetSpeedAmount();
        float playerGravity = playerStats.GetRB().gravityScale;
        playerStats.GetRB().gravityScale = 0;
        playerStats.GetRB().velocity = new Vector2(playerStats.GetRB().velocity.x, 0f);
        playerStats.GetRB().AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
        isDashing = true;
        playerStats.SetIsItTakeDamage(false);
        yield return new WaitForSeconds(0.2f);
        playerStats.GetRB().gravityScale = 1;
        yield return new WaitForSeconds(0.1f);
        playerStats.GetRB().gravityScale = playerGravity;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        playerStats.SetSpeedAmaount(playerSpeed);
        yield return new WaitForSeconds(1f);
        playerStats.SetIsItTakeDamage(true);
        isDashing = false;
    }
    private void BounceBackLeft()
    {
        if(isBouncingBack == false && isRat == true && Input.GetAxisRaw("Horizontal") == 1)
        {
            StartCoroutine(BounceBack(-1f));
        }
    }
    private void BounceBackRight()
    {
        if (isBouncingBack == false && isRat == true && Input.GetAxisRaw("Horizontal") == -1)
        {
            StartCoroutine(BounceBack(1f));
        }
    }
    IEnumerator BounceBack(float direction)
    {
        float playerSpeed = playerStats.GetSpeedAmount();
        float playerGravity = playerStats.GetRB().gravityScale;
        playerStats.GetRB().gravityScale = 0;
        playerStats.GetRB().velocity = new Vector2(playerStats.GetRB().velocity.x, 0f);
        playerStats.GetRB().AddForce(new Vector2(bounceBackDistance * direction, 1f), ForceMode2D.Impulse);
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.3f);
        isBouncingBack = true;
        yield return new WaitForSeconds(0.1f);
        playerStats.GetRB().gravityScale = 1;
        yield return new WaitForSeconds(0.1f);
        playerStats.GetRB().gravityScale = playerGravity;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        playerStats.SetSpeedAmaount(playerSpeed);
        yield return new WaitForSeconds(0.1f);
        isBouncingBack = false;
    }
    private void Turn()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(playerStats.GetRB().velocity.y, 0))
        {
            playerStats.GetRB().velocity = Vector2.up * playerStats.GetJumpAmount()/2; // rg.AddForce(atas * jumpspeed,ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                playerStats.GetRB().velocity = Vector2.up * playerStats.GetJumpAmount();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if (animator.GetBool("isJumping") && Mathf.Approximately(playerStats.GetRB().velocity.y, 0))
        {
            animator.SetBool("isJumping", false);
        }
    }  
    public void Punch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Fist");
            isPunching = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Zýplama Durumu
        if (collision.gameObject.name == "Floor")
        {
            animator.SetBool("IsJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Yere Düþme Durumu
        if (collision.gameObject.name == "Floor")
        {
            animator.SetBool("IsJumping", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RatBody"))
        {
            isRat = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RatBody"))
        {
            isRat = false;
        }
    }
}
