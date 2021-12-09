using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicHeavy : PlayerUnits
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.GetComponent<PlayerBattleController>().battleSystem.DialogueText.text = "You used heavy magic attack...";
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool isDead = Opponent.GetComponent<EnemyUnits>().TakeDamage(Player.GetComponent<PlayerBattleController>().MagicDamage * 1.5f);

        if (isDead)
            Player.GetComponent<PlayerBattleController>().battleSystem.State = BattleState.Won;
        else
            Player.GetComponent<PlayerBattleController>().battleSystem.State = BattleState.EnemyTurn;
    }
}
