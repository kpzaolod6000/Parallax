using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 800;
    private float horizontal;
    private bool Grounded;

    private Rigidbody2D rb2D;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();         
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-0.5f,0.5f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

        animator.SetBool("Running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 2.0f,Color.red);
        if (Physics2D.Raycast(transform.position,Vector3.down,2.0f)) // este es la linea trazada para ver el collider
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            animator.SetTrigger("Jumping");
            Jump();
            
        }
    }
    
    private void Jump()
    {
        rb2D.AddForce(Vector2.up*jumpForce);
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontal * speed, rb2D.velocity.y);
    }
}
