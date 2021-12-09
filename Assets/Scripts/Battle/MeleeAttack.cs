using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : EnemyUnits
{
    public int a;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.transform.LookAt(Opponent.transform.position);
        animator.SetBool("Battle", true);

        NPC.GetComponent<EnemyAI>().InBattle();

        a = Random.Range(1, 5);

        if (NPC.GetComponent<EnemyAI>().battleSystem.State == BattleState.EnemyTurn)
        {
            if (NPC.GetComponent<EnemyAI>().IsHeavy)
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
            NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }
    }
}