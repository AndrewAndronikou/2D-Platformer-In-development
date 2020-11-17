using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCollider;
    GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boxCollider.enabled = false;
            anim.SetBool("Activated", true);
            player.GetComponent<Health>().respawnPoint = gameObject.transform;
        }
    }
}
