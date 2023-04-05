using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMeca : MonoBehaviour
{
    // Start is called before the first frame update

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 5000f;
    [SerializeField] private float dashingTime = 0.1f;
    [SerializeField] private float dashingCooldown = 1f;

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
            StartCoroutine(Dash());
        }

        if (isDashing)
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
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, rb.velocity.y);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}
