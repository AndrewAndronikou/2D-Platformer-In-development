using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    Animator anim;
    [SerializeField] int boxHealth = 2;
    [SerializeField] GameObject destroyVFX;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Die()
    {
        Instantiate(destroyVFX, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(gameObject, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            boxHealth--;

            if (boxHealth <= 0)
            {
                Die();
            }

            anim.SetBool("isHit", true);
            
            if (anim.GetBool("isHit"))
            {
                anim.Play("BoxHit");
                anim.SetBool("isHit", false);
            }

        }
    }
}
