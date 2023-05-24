using System.Collections;
using UnityEngine;

public class DoubleJump : MonoBehaviour
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

    bool unlockdash = false;

    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        remainingJumps = maxJumps;

        CapsulPlayer = GetComponent<CapsuleCollider2D>();

    }

    private void Update()
    {

        if (!isDashing /*&& colere == true*/)
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


        


    }

   



    //Permet au joueur de ne pas glisser sur les plateforme tout en ne restant pas accroché aux murs

    private void OnTriggerEnter2D(Collider2D collision)
    {



        IsGrounded = true;
        CapsulPlayer.sharedMaterial.friction = 10;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;

        if (collision.gameObject.CompareTag("dash"))
        {
            unlockdash = true;
        }




    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        IsGrounded = false;
        CapsulPlayer.sharedMaterial.friction = 0;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;




    }



    public LayerMask groundLayer;
    public float groundCheckRadius;
    private bool CheckIsGrounded()
    {
        Vector2 groundCheckPosition = new Vector2(transform.position.x, transform.position.y - CapsulPlayer.size.y * 0.6f);
        return Physics2D.OverlapCircle(groundCheckPosition, groundCheckRadius, groundLayer);
    }
    


}
