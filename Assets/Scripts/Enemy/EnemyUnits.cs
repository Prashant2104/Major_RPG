using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnits : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject Opponent;
    //public GameObject BattleSystem;

    float currentHP;
    float maxHP;
    float defence;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        Opponent = NPC.GetComponent<EnemyAI>().battleSystem.Player_GO;
        //Opponent = NPC.GetComponent<EnemyAI>().GetPlayer();
        //BattleSystem = NPC.GetComponent<EnemyAI>().GetBattleSystem();

        currentHP = NPC.GetComponent<EnemyAI>().CurrentHP;
        maxHP = NPC.GetComponent<EnemyAI>().MaxHP;
        defence = NPC.GetComponent<EnemyAI>().Defence;
    }
    /*public bool TakeDamage(float Dmg)
    {
        currentHP -= (Dmg - defence);

        NPC.GetComponent<EnemyAI>().CurrentHP = currentHP;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }*/
}