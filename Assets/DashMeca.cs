using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMeca : MonoBehaviour
{
    // Start is called before the first frame update

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 350f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f;
    public bool cotedroit;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;


    


    void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()

    {

        if (isDashing)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            if(rb.velocity.x>0)
            {
                StartCoroutine(Dash());
                
            }
            else
            {

                rb.velocity *= -1;
                StartCoroutine(Dash());
                
                rb.velocity *= -1;
            }
                
        }
        //if input a gauche quand tu fais le isdashing le rb veloctity -


        if(isDashing)
        {
            return;
        }
    }



    private IEnumerator Dash()

    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}
