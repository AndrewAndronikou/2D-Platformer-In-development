using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnCollision : MonoBehaviour
{
    [SerializeField] bool collideMultiple = true;
    bool hasCollided = false;
    int killCount = 0;
    Health playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            playerHealth.Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collideMultiple)
            hasCollided = false;

        if (hasCollided || killCount > 0)
            return;

        if (collision.gameObject.tag == "Player")
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            playerHealth.Die();
            killCount++;
        }        
        else
            hasCollided = true;
    }
}
