using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_Trap : MonoBehaviour
{
    [SerializeField] float bounceForce = 10f;
    [SerializeField] float resetTime = 0.5f;
    bool isActivated = false;

    GameObject player;
    Animator bounceAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bounceAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isActivated = true;

        if(isActivated)
            Bounce();

        StartCoroutine(ResetTrampoline());
    }

    void Bounce()
    {
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bounceForce), ForceMode2D.Impulse);
        bounceAnim.SetTrigger("Bounce");
    }

    IEnumerator ResetTrampoline()
    {
        isActivated = false;

        yield return new WaitForSeconds(resetTime);
    }

}
