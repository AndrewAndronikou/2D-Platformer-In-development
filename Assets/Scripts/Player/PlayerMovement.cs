using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    bool canDoubleJump = false;
    public bool isGrounded = false;
    public bool isLookingRight = true;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
            Jump();

        //if (joystick.Horizontal >= 0.1f || joystick.Horizontal <= -0.1f)
        //    MoveWithJoystick();
        //else
        //    anim.SetBool("isRunning", false);

        if (Input.GetButton("Horizontal"))
            MoveWithKeyboard();
        else
            anim.SetBool("isRunning", false);

    }

    void MoveWithJoystick()
    {
        Vector3 movement = new Vector3(joystick.Horizontal, 0f, 0f);

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

    void MoveWithKeyboard()
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

    public void Jump()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            canDoubleJump = true;
        }
        else
        {
            if (canDoubleJump)
            {
                canDoubleJump = false;
                GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
                anim.SetTrigger("doubleJump");
            }
            anim.ResetTrigger("doubleJump");
        }
    }
}
