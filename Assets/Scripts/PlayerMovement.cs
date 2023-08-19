using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator m_Animator;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isJumping;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckOffset = 1f;
    

    // Start is called before the first frame update 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        groundCheck.position = new Vector3(transform.position.x, transform.position.y - groundCheckOffset, transform.position.z);
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 6f, rb.velocity.y);

        if (isGrounded)
        {
            isJumping = false;
            m_Animator.SetBool("Jump", false);
            m_Animator.SetBool("Fall", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }
        if (rb.velocity.y > 0 && !isGrounded)
        {
            isJumping = true;
            m_Animator.SetTrigger("Jump");
        }

         if(Mathf.Abs(dirX) > 0.001f) {
            m_Animator.SetFloat("xMove", Mathf.Abs(dirX));
            m_Animator.SetFloat("Run", 1f);

        if ((dirX > 0 && !isFacingRight) || (dirX < 0 && isFacingRight)) {
            Flip();
            }
        } else {
            m_Animator.SetFloat("xMove", 0f);
            m_Animator.SetFloat("Run", 0f);
        }
        if (rb.velocity.y < 0 && !isGrounded && isJumping)
        {
            m_Animator.SetBool("Fall", true);

        }
        else
        {
            m_Animator.SetBool("Fall", false);
        }

    }
    private void FixedUpdate()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
