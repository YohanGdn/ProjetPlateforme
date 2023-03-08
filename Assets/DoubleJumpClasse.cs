using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpClasse : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    float horizontal_value;
    Vector2 ref_velocity = Vector2.zero;


    [SerializeField] float jumpForce = 10f;
    [SerializeField] float moveSpeed_horizontal = 400.0f;
    [Range(-10, 10)] [SerializeField] float smooth_time = 1f;
    bool is_jumping = false;
    bool can_jump = false;
    



    [SerializeField] bool IsGrounded = false;
    [SerializeField] int CountJump = 2;
    private int LastPressedJumpTime = 0;
    private int LastOnGroundTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_value = Input.GetAxis("Horizontal");

        if (horizontal_value > 0) sr.flipX = false;
        else if (horizontal_value < 0) sr.flipX = true;

    


        if (Input.GetKeyDown(KeyCode.Space) && CountJump > 0)
        {
            Jump();

        }
    }
    void Jump()
    {
        // Garantit que nous ne pouvons pas appeler Jump plusieurs fois � partir d'une seule pression
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;
        CountJump -= 1;

        // On augmente la force appliqu�e si on tombe
        // Cela signifie que nous aurons toujours l'impression de sauter le m�me montant
        float force = jumpForce;
        if (rb.velocity.y < 0)
            force -= rb.velocity.y;


        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

    }





    void FixedUpdate()
    {

        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        IsGrounded = true;
        CountJump = 2; //reset double saut quand on touche le sol
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        IsGrounded = false;
    }
}
