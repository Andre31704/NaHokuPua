using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator m_Animator;

    private bool isGrounded;
    private bool isJumping;
    private float isinAir;
    private float xAxis;
    private float yAxis;
    private bool isKneeling = false;
    private string currentAnimaton;

    public LayerMask groundLayer;
    public float SlowedMoveSpeed;
    public float moveSpeed = 6f;

    // Start is called before the first frame update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame, check for inputs
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            Debug.Log("Player is jumping");
        }
        
        // checking for jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
            m_Animator.SetFloat("Jump", 1.0f);
        }
        
        if (Input.GetKeyDown(KeyCode.K) && isGrounded) //kneel when 'K' is pressed
        {
            isKneeling = !isKneeling;
            m_Animator.SetBool("Kneel", isKneeling);
        }

        if (!isGrounded)
        {
            m_Animator.SetFloat("Air", 1.0f);
        }
        else
        {
        m_Animator.SetFloat("Air", 0.0f);
        }
        if (rb.velocity.y < 0 && !isGrounded && isJumping)
        {
            m_Animator.SetFloat("Fall", 1.0f);
        }
        else
        {
            m_Animator.SetFloat("Fall", 0.0f);
        }

        if (rb.velocity.y < 0 && isGrounded)
        {
            m_Animator.SetFloat("Jump", 0.0f);
        }


    }

    // fixedupdate checks physics
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, 1.6f, groundLayer);
        Vector2 rayStart = transform.position;
        Vector2 rayEnd = rayStart + Vector2.down * 1.6f;

        Debug.DrawLine(rayStart, rayEnd, Color.green);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // if player is not kneeling: movement logic
        if (!isKneeling)
        {

            Vector2 vel = new Vector2(0, rb.velocity.y);

            // checking for movements, flips sprite
            if (xAxis < 0)
            {
                vel.x = -moveSpeed;
                Flip(-1);
            }
            else if (xAxis > 0)
            {
                vel.x = moveSpeed;
                Flip(1);
            }
            else
            {
                vel.x = 0;
            }

            //update to new movement
             rb.velocity = vel;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if(isGrounded)
        {
            if (xAxis != 0)
            {
                m_Animator.SetFloat("Jog", 1.0f);
            }
            else
            {
                m_Animator.SetFloat("Jog", 0.0f);
            }
        }

    }

    void Flip(int direction)
    {
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * direction;
        transform.localScale = newScale;
    }

    public void SlowPlayer()
    {
        moveSpeed = SlowedMoveSpeed;
    }

    public void RestorePlayerSpeed()
    {// Restore player speed to normal
        moveSpeed = 6f; // Adjust this value according to your default speed
    } 
}
