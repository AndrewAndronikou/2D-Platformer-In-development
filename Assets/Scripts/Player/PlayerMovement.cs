using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    public bool isGrounded = false;
    public bool isLookingRight = true;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
            Jump();

        if (Input.GetButton("Horizontal"))
            Move();
        else
            anim.SetBool("isRunning", false);
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        anim.SetBool("isRunning", true);

        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
            isLookingRight = true;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            isLookingRight = false;
        }
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        anim.SetTrigger("jump");
    }
}
