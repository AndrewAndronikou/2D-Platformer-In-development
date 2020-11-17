using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Trap : MonoBehaviour
{
    [SerializeField] float windPower = 10f;
    bool isActivated = true;

    GameObject player;
    Animator fanAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fanAnim = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Push();
    }

    void Push()
    {
        Debug.Log("PUSH");
       // player.transform.Translate((Vector2.up * 10f) + (Vector2.up * windPower) * Time.deltaTime);
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, windPower), ForceMode2D.Impulse);
    }
}
