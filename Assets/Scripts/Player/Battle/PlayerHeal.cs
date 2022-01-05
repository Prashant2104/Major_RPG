using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : PlayerUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Player.GetComponent<PlayerBattleController>().battleSystem.DialogueText.text = "You used Heal...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            Player.GetComponent<PlayerBattleController>().battleSystem.DialogueText.text = "You heal yourself...";
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.GetComponent<PlayerBattleController>().Heal.Stop();

        Player.GetComponent<PlayerBattleController>().battleSystem.inventory.HealButton();

        Player.GetComponent<PlayerBattleController>().battleSystem.State = BattleState.EnemyTurn;
        Player.GetComponent<PlayerBattleController>().battleSystem.EnemyTurn();
    }
}