using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Trap : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] float activationTime = 1.0f;
    [SerializeField] float resetTime = 3.0f;


    bool isActivated = false;

    GameObject player;
    Animator activatedAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activatedAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger enter");

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
