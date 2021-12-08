using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Buff...";
        animator.SetBool("Buff", false);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<EnemyAI>().Defence += 5;
    }
}
