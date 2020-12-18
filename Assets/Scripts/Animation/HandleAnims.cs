using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnims : MonoBehaviour
{
    Health health;
    Animator anim;
    [SerializeField] float animWaitTime = 0.5f;

    void Start()
    {
        health = GetComponent<Health>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (health.hasTakenDamage)
        {
            if (!health && !anim)
            {
                Debug.Log("Health & Anim not found");
                return;
            }
            anim.SetTrigger("Hit");
            StartCoroutine(HasTakenDamage());
        }
    }

    IEnumerator HasTakenDamage()
    {
        yield return new WaitForSeconds(0.5f);
        anim.ResetTrigger("Hit");
        health.hasTakenDamage = false;
    }
}
