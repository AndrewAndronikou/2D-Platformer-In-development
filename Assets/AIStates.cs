using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStates : MonoBehaviour
{
    [SerializeField] float resetDistance = 5.0f;
    [SerializeField] float stateDelayTime = 1.0f;

    EnemyAI enemyAI;
    BoxCollider2D activationArea;

    //Fix return to start position
    [SerializeField] Vector3 startPosition;

    Rigidbody2D rb;
    Animator anim;

    public enum AIState { Idle, Activating, Deactivating, Attacking }
    [SerializeField] public AIState state = AIState.Idle;
    
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        enemyAI.enabled = false;
        activationArea = GetComponentInChildren<BoxCollider2D>();
        //
        startPosition = gameObject.transform.position;
        //
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        switch (state)
        {
            case AIState.Idle:
                IdleBehaviour();
                break;

            case AIState.Activating:
                ActivatingBehaviour();
                break;

            case AIState.Deactivating:
                DeactivatingBehaviour();
                break;

            case AIState.Attacking:
                AttackingBehaviour();
                break;
        }
    }

    void IdleBehaviour()
    {
        Debug.Log(state);
        enemyAI.enabled = false;
        activationArea.enabled = true;
    }

    void ActivatingBehaviour()
    {
        Debug.Log(state);

        activationArea.enabled = false;
        anim.SetBool("isActive", true);

        StartCoroutine(ActivationDelay(stateDelayTime, AIState.Attacking));
    }

    void DeactivatingBehaviour()
    {
        Debug.Log(state);
        enemyAI.enabled = false;
        MoveTo(startPosition);       

        float distanceTo = Vector3.Distance(startPosition, gameObject.transform.position);

        if (FastApproximately(gameObject.transform.position.x, startPosition.x, 0.01f) &&
            FastApproximately(gameObject.transform.position.y, startPosition.y, 0.01f))
        {
            anim.SetBool("isActive", false);
            Debug.Log("Returned to Position");
            StartCoroutine(ActivationDelay(stateDelayTime, AIState.Idle));
        }
    }

    void AttackingBehaviour()
    {
        Debug.Log(state);
        enemyAI.enabled = true;

        float distanceTo = Vector3.Distance(enemyAI.target.position, gameObject.transform.position);

        if(distanceTo > resetDistance)
            state = AIState.Deactivating;
    }

    void MoveTo(Vector3 position)
    {
        Vector3 direction = ((Vector2)startPosition - rb.position).normalized;
        Vector3 force = direction * enemyAI.speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, startPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            state = AIState.Activating;
        }
    }

    private bool FastApproximately(float a, float b, float threshold)
    {
        return ((a - b) < 0 ? ((a - b) * -1) : (a - b)) <= threshold;
    }

    IEnumerator ActivationDelay(float delayTime, AIState desiredState)
    {
        yield return new WaitForSeconds(delayTime);
        state = desiredState;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, resetDistance);
    }
}
