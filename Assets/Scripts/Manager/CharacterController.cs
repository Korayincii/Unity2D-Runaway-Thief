using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public Vector2 runDirection = Vector2.right;
    public float jumpForce = 100f; // Force of character's jump
    private bool isGrounded = true;
    public float speed = 5f;
    CharacterStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<CharacterStats>().currentHealth !<= 0)
        {
			speed += Time.deltaTime * 0.2f;
		}
       
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
        // Update Rigidbody2D velocity based on run direction
        rb.velocity = new Vector2(runDirection.x * speed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {
            anim.SetBool("sliding", true);

        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("sliding", false);
        }


    }

    public void Jump()
    {
        // Apply jump force to Rigidbody2D
        rb.velocity = new Vector2(rb.velocity.x, jumpForce );
        anim.SetBool("jumping",true);
        isGrounded = false; // Set grounded flag to false
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if character is grounded
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true; // Set grounded flag to true
            anim.SetBool("jumping", false);
        }

        if (collision.gameObject.tag == "Wall")
        {
            stats.TakeDamage();
            Destroy(collision.gameObject);

        }
    }


}
