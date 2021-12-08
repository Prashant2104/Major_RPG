using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Heavy attack...";
        animator.SetBool("Heavy", false);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool isDead = Opponent.GetComponent<PlayerUnits>().TakeDamage(NPC.GetComponent<EnemyAI>().MeleeDamage * 1.5f);

        if (isDead)
        {
            //GameOver
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.Lost;
        }
    }
}
