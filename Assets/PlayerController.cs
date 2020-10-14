using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 600.0f;
    public float jumpForce = 1;
    public Rigidbody2D rb;

    public float xDisplacement;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
    }
}