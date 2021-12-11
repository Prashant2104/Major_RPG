using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : EnemyUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Buff...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy's attack increased...";
        }        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<EnemyAI>().MeleeDamage += 2.5f;
        NPC.GetComponent<EnemyAI>().MagicDamage += 2.5f;
      
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
        NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;

        animator.SetTrigger("Attack");
    }
}