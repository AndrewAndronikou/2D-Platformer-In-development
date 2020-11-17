using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnCollision : MonoBehaviour
{
    Health playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

            playerHealth.Die();
        }
    }
}
