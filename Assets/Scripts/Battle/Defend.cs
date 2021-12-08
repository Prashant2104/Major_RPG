using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used light attack...";
        animator.SetBool("KnightDefend", false);
        animator.SetBool("BrawlerDefend", false);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*bool isDead = Opponent.GetComponent<PlayerUnits>().TakeDamage(NPC.GetComponent<EnemyAI>().MeleeDamage);

        if (isDead)
        {
            //GameOver
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.Lost;
        }
        else
        {
            //PlayerTurn
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }*/
    }
}
