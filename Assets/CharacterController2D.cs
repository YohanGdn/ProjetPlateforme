

using System.Collections;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    public int maxJumps = 1;

    [SerializeField] DashMeca dashMeca;

    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    

    CapsuleCollider2D CapsulPlayer;


    public Animator animator;


    private Rigidbody2D rb;
    
    private SpriteRenderer sr;
    
    private bool isDashing = false;

    private bool canDash = true;
    
    [SerializeField]public int remainingJumps;

    private bool hasJumped = false; // Nouvelle variable




    /*
    private bool tris;
    private bool joie;
    private bool colere;
    private bool defaulttype;
    */


    [SerializeField] private TrailRenderer tr;

    [SerializeField] bool IsGrounded = true;

    bool unlockdash = false;
    public bool unlockDoubleJump = false;





    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        sr = GetComponent<SpriteRenderer>();
        
        remainingJumps = maxJumps;
        hasJumped = false; // Réinitialise la variable hasJumped lorsque le personnage est au sol

        CapsulPlayer = GetComponent<CapsuleCollider2D>();

    }

    private void Update()
    {

        if (!isDashing ) //gameObject.GetComponent<DashMeca>().colere)
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
            float characterVelocity = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("Speed", characterVelocity);
        }






        if (CheckIsGrounded())
        {
            
            hasJumped = false; // Réinitialise la variable hasJumped lorsque le personnage est au sol

        }

        if (remainingJumps >= 0 && Input.GetKeyDown(KeyCode.Space) && (remainingJumps == 1 || (remainingJumps == 2 && unlockDoubleJump)))
        {
            remainingJumps--;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (canDash && Input.GetKeyDown(KeyCode.LeftShift) && unlockdash == true && dashMeca.colere == true)
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

    public void OnTriggerEnter2D(Collider2D collision)
    {

        remainingJumps = maxJumps;

        IsGrounded = true;
        CapsulPlayer.sharedMaterial.friction = 10;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;
        
        
        if (collision.gameObject.CompareTag("dash"))
        {
            unlockdash = true;
        }

        if (collision.gameObject.CompareTag("DoubleJump"))
        {
            unlockDoubleJump = true;
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
