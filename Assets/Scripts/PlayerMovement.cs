using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator m_Animator;
    private bool isFacingRight = true;
    

    // Start is called before the first frame update 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 6f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, 7f);
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

    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
