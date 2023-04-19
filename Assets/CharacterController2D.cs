using System.Collections;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    CapsuleCollider2D CapsulPlayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isDashing = false;
    private bool canDash = true;
    private int remainingJumps;

    [SerializeField] private TrailRenderer tr;

    [SerializeField] bool IsGrounded = true;

    enum Test { state1, state2, state3, state4 };
    Test myEnum = Test.state1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        remainingJumps = maxJumps;

        CapsulPlayer = GetComponent<CapsuleCollider2D>();

    }

    private void Update()
    {

        UpdateSwitchState();
        if (!isDashing)
        {
            float horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

            if (horizontal > 0)
            {
                sr.flipX = false;
            }
            else if (horizontal < 0)
            {
                sr.flipX = true;
            }
        }

        if (CheckIsGrounded())
        {
            remainingJumps = maxJumps;
        }

        if (remainingJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            remainingJumps--;
        }

        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        float dashDirection = sr.flipX ? -1f : 1f;

        rb.velocity = new Vector2(dashDirection * dashSpeed, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        tr.emitting = false;
        rb.gravityScale = originalGravity;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        
    }

    //Permet au joueur de ne pas glisser sur les plateforme tout en ne restant pas accroché aux murs

    private void OnTriggerEnter2D(Collider2D collision)
    {

        IsGrounded = true;
        CapsulPlayer.sharedMaterial.friction = 10;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CapsulPlayer.sharedMaterial.friction = 0;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;

        IsGrounded = false;
    }

    public LayerMask groundLayer;
    public float groundCheckRadius;
    private bool CheckIsGrounded()
    {
        Vector2 groundCheckPosition = new Vector2(transform.position.x, transform.position.y - CapsulPlayer.size.y * 0.6f);
        return Physics2D.OverlapCircle(groundCheckPosition, groundCheckRadius, groundLayer);
    }


    
    

    // Update is called once per frame
    void UpdateSwitchState()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            switch (myEnum)
            {
                case Test.state1:
                    myEnum = Test.state2;
                    break;
                case Test.state2:
                    myEnum = Test.state3;
                    break;
                case Test.state3:
                    myEnum = Test.state4;
                    break;
                case Test.state4:
                    myEnum = Test.state1;
                    break;
            }
            UpdateState();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
             
            switch (myEnum)
            {
                case Test.state1:
                    myEnum = Test.state4;
                    break;
                case Test.state2:
                    myEnum = Test.state1;
                    break;
                case Test.state3:
                    myEnum = Test.state2;
                    break;
                case Test.state4:
                    myEnum = Test.state3;
                    break;
            }
            UpdateState();
        }
       
    }
    // Création méthode avec Alt + Entrée
    private void UpdateState()
    {
        switch (myEnum)
        {
            case Test.state1:
                Debug.Log("State1");
                break;
            case Test.state2:
                Debug.Log("State2");
                break;
            case Test.state3:
                Debug.Log("State3");
                break;
            case Test.state4:
                Debug.Log("State4");
                break;
        }
    }
}
