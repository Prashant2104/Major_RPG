using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : EnemyUnits
{
    [SerializeField] int a;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        ThisEnemy.transform.LookAt(Opponent.transform.position);

        ThisEnemy.GetComponent<EnemyAI>().OnAwake.Play();

        animator.SetBool("Battle", true);

        ThisEnemy.GetComponent<EnemyAI>().InBattle();

        a = Random.Range(1, 5);
        if (a == 1)
        {
            if (ThisEnemy.GetComponent<EnemyAI>().MeleeDefence + 1.5f >= Opponent.GetComponent<PlayerBattleController>().MeleeDamage ||
                        ThisEnemy.GetComponent<EnemyAI>().MagicDefence + 1.5f >= Opponent.GetComponent<PlayerBattleController>().MagicDamage)
            {
                a = 4;
            }
        }        

        if (ThisEnemy.GetComponent<EnemyAI>().IsMelee && !ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            if (ThisEnemy.GetComponent<EnemyAI>().IsHeavy)
            {
                switch (a)
                {
                    case 4:
                        animator.SetTrigger("Light");
                        break;
                    case 1:
                        animator.SetTrigger("DefendB");
                        break;
                    case 2:
                        animator.SetTrigger("Buff");
                        break;
                    case 3:
                        animator.SetTrigger("Heavy");
                        break;
                }
            }
            else
            {
                switch (a)
                {
                    case 4:
                        animator.SetTrigger("Light");
                        break;
                    case 1:
                        animator.SetTrigger("DefendK");
                        break;
                    case 2:
                        animator.SetTrigger("Buff");
                        break;
                    case 3:
                        animator.SetTrigger("Light");
                        break;
                }
            }
        }

        else if (!ThisEnemy.GetComponent<EnemyAI>().IsMelee && ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            if (ThisEnemy.GetComponent<EnemyAI>().IsHeavy)
            {
                switch (a)
                {
                    case 4:
                        animator.SetTrigger("Light");
                        break;
                    case 1:
                        animator.SetTrigger("Defend");
                        break;
                    case 2:
                        animator.SetTrigger("Buff");
                        break;
                    case 3:
                        animator.SetTrigger("Heavy");
                        break;
                }
            }
            else
            {
                switch (a)
                {
                    case 4:
                        animator.SetTrigger("Light");
                        break;
                    case 1:
                        animator.SetTrigger("Defend");
                        break;
                    case 2:
                        animator.SetTrigger("Buff");
                        break;
                    case 3:
                        animator.SetTrigger("Light");
                        break;
                }
            }
        }

        else if (ThisEnemy.GetComponent<EnemyAI>().IsMelee && ThisEnemy.GetComponent<EnemyAI>().IsMagic)
        {
            switch (a)
            {
                case 4:
                    animator.SetTrigger("Light");
                    break;
                case 1:
                    animator.SetTrigger("Defend");
                    break;
                case 2:
                    animator.SetTrigger("Buff");
                    break;
                case 3:
                    animator.SetTrigger("Heavy");
                    break;
            }
        }
        /*if (NPC.GetComponent<EnemyAI>().battleSystem.State != BattleState.Lost || NPC.GetComponent<EnemyAI>().battleSystem.State != BattleState.Won)
        {
            NPC.GetComponent<EnemyAI>().battleSystem.DialogueText.text = "Choose an action...";
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }*/
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisEnemy.transform.LookAt(Opponent.transform.position);
    }
}