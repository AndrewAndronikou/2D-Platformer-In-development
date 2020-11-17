using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float timeBeforeFall = 2f;
    [SerializeField] float fallSpeed = 5f;
    [SerializeField] float respawnTime = 3f;
    [SerializeField] GameObject spawnVFX;

    bool isActivated = true;
    Vector2 startPosition;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated)
        {
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
            StartCoroutine(Respawn());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StartCoroutine(StartFalling());
    }

    IEnumerator StartFalling()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        isActivated = false;
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        while (!isActivated)
        {
            transform.position = startPosition;
            Instantiate(spawnVFX, transform.position, Quaternion.identity);
            isActivated = true;
        }
    }
}
