using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Trap : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] float activationTime = 1.0f;
    [SerializeField] float resetTime = 3.0f;

    bool isActivated = false;
    Animator activatedAnim;

    // Start is called before the first frame update
    void Start()
    {
        activatedAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
             StartCoroutine(ActivateTrap());    
    }

    IEnumerator ActivateTrap()
    {
        isActivated = true;
        if (isActivated)
            activatedAnim.SetBool("Activate", true);

        yield return new WaitForSeconds(activationTime);

        fire.SetActive(true);

        StartCoroutine(ResetTrap());
    }

    IEnumerator ResetTrap()
    {
        yield return new WaitForSeconds(resetTime);

        isActivated = false;
        if (!isActivated)
            activatedAnim.SetBool("Activate", false);

        fire.SetActive(false);
    }
}
