using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Heavy attack...";
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetTrigger("Attack");
        bool isDead = Opponent.GetComponent<PlayerBattleController>().TakeDamage(NPC.GetComponent<EnemyAI>().MeleeDamage * 1.5f);

        if (isDead)
        {
            //GameOver
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.Lost;
            NPC.GetComponent<EnemyAI>().battleSystem.EndBattle();
        }
        else
        {
            NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }
    }
}
