using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnits : StateMachineBehaviour
{
    public GameObject Player;
    public GameObject Opponent;

    float defence;
    float maxHP;
    float currentHP;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = animator.gameObject;
        Opponent = Player.GetComponent<PlayerBattleController>().Enemy;

        Player.GetComponent<PlayerBattleController>().OnAwake.Play();

        currentHP = Player.GetComponent<PlayerBattleController>().CurrentHP;
        maxHP = Player.GetComponent<PlayerBattleController>().MaxHP;
        defence = Player.GetComponent<PlayerBattleController>().MeleeDefence;
    }

    public bool TakeDamage(float Dmg)
    {
        currentHP -= (Dmg - defence);

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}