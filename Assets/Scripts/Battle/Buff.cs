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
        ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy used Buff...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Enemy's attack increased...";
        }        
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisEnemy.GetComponent<EnemyAI>().Buff.Stop();

        if (ThisEnemy.GetComponent<EnemyAI>().IsMelee && !ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            ThisEnemy.GetComponent<EnemyAI>().MeleeDamage += 1.0f;
            ThisEnemy.GetComponent<EnemyAI>().MagicDamage += 0.5f;
        }
        else if (!ThisEnemy.GetComponent<EnemyAI>().IsMelee && ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            ThisEnemy.GetComponent<EnemyAI>().MeleeDamage += 0.5f;
            ThisEnemy.GetComponent<EnemyAI>().MagicDamage += 1.0f;
        }
        else if (ThisEnemy.GetComponent<EnemyAI>().IsMelee && ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            ThisEnemy.GetComponent<EnemyAI>().MeleeDamage += 1.0f;
            ThisEnemy.GetComponent<EnemyAI>().MagicDamage += 1.0f;
        }

        ThisEnemy.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
        ThisEnemy.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;

        animator.SetTrigger("Attack");
    }
}