using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Buff...";
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<EnemyAI>().MeleeDamage += 2.5f;
        NPC.GetComponent<EnemyAI>().MagicDamage += 2.5f;
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy's attack increased...";

        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
        NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
    }
}
