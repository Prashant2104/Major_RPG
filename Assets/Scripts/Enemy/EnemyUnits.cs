using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnits : StateMachineBehaviour
{
    public GameObject ThisEnemy;
    public GameObject Opponent;
    //public GameObject BattleSystem;

    float currentHP;
    float maxHP;
    float magicDefence;
    float meleeDefence;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisEnemy = animator.gameObject;
        Opponent = ThisEnemy.GetComponent<EnemyAI>().battleSystem.Player_GO;
        //Opponent = NPC.GetComponent<EnemyAI>().GetPlayer();
        //BattleSystem = NPC.GetComponent<EnemyAI>().GetBattleSystem();

        //currentHP = NPC.GetComponent<EnemyAI>().CurrentHP;
        //maxHP = NPC.GetComponent<EnemyAI>().MaxHP;
        //meleeDefence = NPC.GetComponent<EnemyAI>().MeleeDefence;
        //magicDefence = NPC.GetComponent<EnemyAI>().MagicDefence;
    }
}