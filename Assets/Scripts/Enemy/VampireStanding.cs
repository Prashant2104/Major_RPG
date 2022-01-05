using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireStanding : EnemyUnits
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisEnemy.transform.LookAt(Opponent.transform.position);

        ThisEnemy.GetComponent<EnemyAI>().OnAwake.Play();

        animator.SetBool("Battle", true);

        ThisEnemy.GetComponent<EnemyAI>().InBattle();
    }
}
