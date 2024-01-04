using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float viewDistance;
    public float wanderDistance;
    public float speed;
    public Transform target;
    public Animator animator;

    Rigidbody rb;
    NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target == null) return;

        var currentSpeed = agent.velocity.magnitude;
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < 1.5f)
        {
            // JUMPSCARE
            speed = 0;
            animator.Play("Scream");
        }
        else if (currentSpeed == 0)
        {
            animator.Play("Idle");
        }
        
        else
        {
            animator.Play("Run");
        }

        agent.speed = speed;

        if (distance < viewDistance)
        {
            agent.destination = target.position;
        }
        else
        {
            if (agent.velocity == Vector3.zero)
            {
                var offset = Random.insideUnitSphere * wanderDistance;
                agent.destination = transform.position + offset;
            }
        }


    }
}
