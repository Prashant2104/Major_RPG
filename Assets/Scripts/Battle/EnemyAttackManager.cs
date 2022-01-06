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

        if(!ThisEnemy.GetComponent<AudioSource>().isPlaying)
            ThisEnemy.GetComponent<AudioSource>().Play();

        a = Random.Range(1, 5);
        if (a == 1)
        {
            if (ThisEnemy.GetComponent<EnemyAI>().MeleeDefence + 2f >= Opponent.GetComponent<PlayerBattleController>().MeleeDamage ||
                        ThisEnemy.GetComponent<EnemyAI>().MagicDefence + 2f >= Opponent.GetComponent<PlayerBattleController>().MagicDamage)
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
            int x = Random.Range(1, 3);
            switch (a)
            {
                case 4:
                    if(x == 1)
                        animator.SetTrigger("LightMelee");
                    if(x==2)
                        animator.SetTrigger("LightMagic");
                    break;

                case 1:
                    animator.SetTrigger("Defend");
                    break;

                case 2:
                    animator.SetTrigger("Buff");
                    break;

                case 3:
                    if (x == 1)
                        animator.SetTrigger("HeavyMelee");
                    if (x == 2)
                        animator.SetTrigger("HeavyMagic");
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