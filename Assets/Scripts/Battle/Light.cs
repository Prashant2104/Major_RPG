using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : EnemyUnits
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used light attack...";
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        Debug.Log("Light");
        bool isDead = Opponent.GetComponent<PlayerBattleController>().TakeDamage(NPC.GetComponent<EnemyAI>().MeleeDamage);

        if(isDead)
        {
            //GameOver
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.Lost;
        }
    }
}