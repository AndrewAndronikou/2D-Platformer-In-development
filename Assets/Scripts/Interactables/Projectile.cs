using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] int damage;
    [SerializeField] float lifeTime;
    [SerializeField] bool destroyedByCollision;
    [SerializeField] GameObject dieVFX;

    Health health;

    private void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Collidable")
        //{
        //    DestroyProjectile();
        //}
        //if (collision.tag == "Enemy" || collision.tag == "Player")
        //{
        //    health = collision.GetComponent<Health>();
        //    health.TakeDamage(damage);
        //    DestroyProjectile();
        //}
        //if (collision.tag == "Player")
        //{
        //    health = collision.GetComponent<Health>();
        //    health.Die();
        //    DestroyProjectile();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collidable")
        {
            DestroyProjectile();
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
            DestroyProjectile();
        }
        if (collision.gameObject.tag == "Player")
        {
            health = collision.gameObject.GetComponent<Health>();
            health.Die();
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Instantiate(dieVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
