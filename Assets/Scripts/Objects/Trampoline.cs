using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (other.gameObject.GetComponent<Rigidbody2D>().velocity.x,jumpForce);
            other.gameObject.GetComponent<Animator>().SetBool("jumping", true); 
        }
    }
}
