using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            boxCollider.enabled = false;
            anim.SetBool("Activated", true);
            collision.GetComponent<Health>().respawnPoint = gameObject.transform;
        }
    }
}
