using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] float damage;
    [SerializeField] float lifeTime;
    [SerializeField] bool destroyedByCollision;

    [SerializeField] GameObject dieVFX;

    private void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collidable")
        {
            Die();
        }
        if (collision.tag == "Enemy")
        { 
            //Once enemy created fill this out.
        }
    }

    void Die()
    {
        Instantiate(dieVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
