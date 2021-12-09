using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : EnemyUnits
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used light attack...";
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<EnemyAI>().Defence += 1.5f;
        NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy's defence increased...";
    }
}
