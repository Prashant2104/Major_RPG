using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMelee : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Heavy attack...";
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetTrigger("Attack");
        bool isDead = Opponent.GetComponent<PlayerBattleController>().TakeMeleeDamage(ThisEnemy.GetComponent<EnemyAI>().MeleeDamage * 1.5f);

        if (isDead)
        {
            //GameOver
            ThisEnemy.GetComponent<EnemyAI>().battleSystem.State = BattleState.Lost;
            ThisEnemy.GetComponent<EnemyAI>().battleSystem.EndBattle();
        }
        else
        {
            ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
            ThisEnemy.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }
    }
}
