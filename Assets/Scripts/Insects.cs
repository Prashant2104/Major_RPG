using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Insects : MonoBehaviour
{
    GameObject[] Goal;
    public GameObject Player;
    public float RunDistance;

    NavMeshAgent agent;
    Animator anim;
    void Start()
    {
        Goal = GameObject.FindGameObjectsWithTag("Goal");

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.SetDestination(Goal[Random.Range(0, Goal.Length)].transform.position);
        agent.speed = 2f;
        anim.SetTrigger("Walk");
    }
    void FixedUpdate()
    {
        float playerDist = Vector3.Distance(transform.position, Player.transform.position);

        if(playerDist < RunDistance)
        {
            Vector3 direction = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + direction;

            agent.SetDestination(newPos);

            agent.speed = 5f;
            anim.SetTrigger("Run");
        }
        else if(agent.remainingDistance < 1)
        {
            agent.SetDestination(Goal[Random.Range(0, Goal.Length)].transform.position);
            agent.speed = 2f;
            anim.SetTrigger("Walk");
        }
    }
}