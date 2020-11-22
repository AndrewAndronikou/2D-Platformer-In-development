using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Head : MonoBehaviour
{  
    BoxCollider2D collider2DTrigger;
    Rigidbody2D rigidbody;
    DeathOnCollision deathOnCollision;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        collider2DTrigger = GetComponent<BoxCollider2D>();
        deathOnCollision = GetComponentInChildren<DeathOnCollision>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rigidbody = GetComponentInChildren<Rigidbody2D>();
            rigidbody.gravityScale = 1f;
            collider2DTrigger.enabled = false;
            anim.SetBool("hasCollided", true);
        }
    }
}
