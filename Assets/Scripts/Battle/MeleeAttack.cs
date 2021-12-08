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
                        animator.SetBool("Light", true);
                        break;
                    case 1:
                        animator.SetBool("BrawlerDefend", true);
                        break;
                    case 2:
                        animator.SetBool("Buff", true);
                        break;
                    case 3:
                        animator.SetBool("Heavy", true);
                        break;
                }
            }
            else
            {
                switch (a)
                {
                    case 4:
                        animator.SetBool("Light", true);
                        break;
                    case 1:
                        animator.SetBool("KnightDefend", true);
                        break;
                    case 2:
                        animator.SetBool("Buff", true);
                        break;
                    case 3:
                        animator.SetBool("Light", true);
                        break;
                }
            }
            //NPC.GetComponent<EnemyAI>().battleSystem.State = BattleState.PlayerTurn;
        }
    }
}