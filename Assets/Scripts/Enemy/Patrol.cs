using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : EnemyPatrol
{
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private int currentWP;

    private void Awake()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("Waypoints");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC = animator.gameObject;
        //currentWP = Random.Range(0, wayPoints.Length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (wayPoints.Length == 0)
            return;

        if(Vector3.Distance(wayPoints[currentWP].transform.position, NPC.transform.position) < Accuracy)
        {
            //currentWP = Random.Range(0, wayPoints.Length);

            currentWP++;
            if(currentWP >= wayPoints.Length)
            {
                currentWP = 0;
            }
        }

        var direction = wayPoints[currentWP].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), RotSpeed * Time.deltaTime);

        NPC.transform.Translate(0, 0, Time.deltaTime * Speed);
    }
}