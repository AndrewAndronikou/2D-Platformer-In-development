using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startHealth = 10;
    public int currentHealth;

    //For Enemies only
    [SerializeField] int scoreWorth = 20;
    [SerializeField] GameObject deathVFX;

    [SerializeField] bool isPlayer = false;

    //For Player only
    public Transform respawnPoint;
    [SerializeField] GameObject respawnVFX;
    [SerializeField]HealthBar healthBar;

    void Start()
    {
        currentHealth = startHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Die();

        if (Input.GetKeyDown(KeyCode.L))
            GiveLife();

        if (currentHealth <= 0)
            Die();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }

    public void GiveLife()
    {
        PlayerStats.Health++;
    }

    public void Die()
    {
        if (isPlayer)
        {
            PlayerStats.Health--;
            healthBar.SetHealth(PlayerStats.Health);
            Debug.Log(PlayerStats.Health);
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            ToggleComponents(false);
            StartCoroutine(RespawnPlayer());
        }

        if (!isPlayer)
        {
            PlayerStats.Score += scoreWorth;
            Destroy(gameObject, 0.5f);
            Instantiate(deathVFX, transform.position, Quaternion.identity);
        }
    }

    IEnumerator RespawnPlayer()
    {
        transform.position = respawnPoint.position;
        Instantiate(respawnVFX, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        ToggleComponents(true);
    }

    void ToggleComponents(bool toggle)
    {
        gameObject.GetComponent<PlayerMovement>().enabled = toggle;
        gameObject.GetComponent<SpriteRenderer>().enabled = toggle;
        gameObject.GetComponent<Shooter>().enabled = toggle;
        gameObject.GetComponent<BoxCollider2D>().enabled = toggle;
        gameObject.GetComponent<Rigidbody2D>().simulated = toggle;
    }
}
