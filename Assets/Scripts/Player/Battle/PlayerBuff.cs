using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : PlayerUnits
{
    [SerializeField] float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Player.GetComponent<PlayerBattleController>().battleSystem.DialogueText.text = "You used buff...";
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            Player.GetComponent<PlayerBattleController>().battleSystem.DialogueText.text = "Your attack increased...";
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.GetComponent<PlayerBattleController>().MeleeDamage += 1.5f;
        Player.GetComponent<PlayerBattleController>().MagicDamage += 1.5f;

        Player.GetComponent<PlayerBattleController>().battleSystem.State = BattleState.EnemyTurn;
        Player.GetComponent<PlayerBattleController>().battleSystem.EnemyTurn();
    }
}