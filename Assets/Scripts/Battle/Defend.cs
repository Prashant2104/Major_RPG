using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : EnemyUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Defence...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer >= 0.7f)
        {
            ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy's defence increased...";
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ThisEnemy.GetComponent<EnemyAI>().IsMelee && !ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            ThisEnemy.GetComponent<EnemyAI>().MeleeDefence += 1.5f;
            ThisEnemy.GetComponent<EnemyAI>().MagicDefence += 1.0f;
        }
        else if (!ThisEnemy.GetComponent<EnemyAI>().IsMelee && ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            ThisEnemy.GetComponent<EnemyAI>().MeleeDefence += 1.0f;
            ThisEnemy.GetComponent<EnemyAI>().MagicDefence += 1.5f;
        }
        else if (ThisEnemy.GetComponent<EnemyAI>().IsMelee && ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            ThisEnemy.GetComponent<EnemyAI>().MeleeDefence += 1.5f;
            ThisEnemy.GetComponent<EnemyAI>().MagicDefence += 1.5f;
        }

        ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
        ThisEnemy.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;

        animator.SetTrigger("Attack");
    }
}