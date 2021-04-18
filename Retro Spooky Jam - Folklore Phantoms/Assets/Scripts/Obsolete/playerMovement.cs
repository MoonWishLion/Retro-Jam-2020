using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Animator anim;

    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Jump();
        // transform.position += movement * Time.deltaTime * moveSpeed;

        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.Play("Player_Run_Animation");
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.Play("Player_Run_Animation");
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        */

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
