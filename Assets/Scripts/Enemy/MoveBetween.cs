using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector3 moveDirection;

    Rigidbody2D rb;
    [SerializeField] SpriteRenderer enemyGFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = moveDirection * speed * Time.deltaTime;
        transform.position += force;

        if (moveDirection.x >= 0.01f)
            enemyGFX.flipX = true;
        else if (moveDirection.x <= -0.01f)
            enemyGFX.flipX = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collidable")
        {
            moveDirection = -moveDirection;
        }
    }
}
