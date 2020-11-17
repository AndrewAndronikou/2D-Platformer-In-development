using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Collidable" || collision.collider.tag == "CollidableJump")
        {
            GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Collidable" || collision.collider.tag == "CollidableJump")
        {
            GetComponent<PlayerMovement>().isGrounded = false;
        }
    }
}
