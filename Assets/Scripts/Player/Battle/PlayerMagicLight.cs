using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicLight : PlayerUnits
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Player.GetComponent<PlayerBattleController>().battleSystem.DialogueText.text = "You used light magic attack...";
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool isDead = Opponent.GetComponent<EnemyAI>().TakeDamage(Player.GetComponent<PlayerBattleController>().MagicDamage);

        if (isDead)
        {
            Player.GetComponent<PlayerBattleController>().battleSystem.State = BattleState.Won;
            Player.GetComponent<PlayerBattleController>().battleSystem.EndBattle();
        }
        else
        {
            Player.GetComponent<PlayerBattleController>().battleSystem.State = BattleState.EnemyTurn;
            Player.GetComponent<PlayerBattleController>().battleSystem.EnemyTurn();
        }            
    }
}
