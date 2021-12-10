using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }
public class BattleSystem : MonoBehaviour
{
    public BattleState State;

    public GameObject Player_TPC;
    public GameObject Player_GO;
    public GameObject Enemy_GO;

    public GameObject BattleHUD;

    public PlayerBattleHUD PlayerHUD;
    public EnemyBattleHUD EnemyHUD;

    public Text DialogueText;

    PlayerBattleController battleController;
    EnemyAI enemyUnits;

    private void OnEnable()
    {
        State = BattleState.Start;
        BattleHUD.SetActive(true);
        StartCoroutine(BattleSetup());
    }
    
    IEnumerator BattleSetup()
    {
        Player_GO.GetComponent<PlayerBattleController>().Enemy = Enemy_GO;
        Player_GO.GetComponent<PlayerBattleController>().battleSystem = this.GetComponent<BattleSystem>();
        Player_GO.SetActive(true);

        battleController = Player_GO.GetComponent<PlayerBattleController>();
        enemyUnits = Enemy_GO.GetComponent<EnemyAI>();

        Player_TPC.SetActive(false);

        DialogueText.text = "You encountered '" + enemyUnits.name + " '";

        PlayerHUD.SetHUD(battleController);
        EnemyHUD.SetHUD(enemyUnits);

        yield return new WaitForSeconds(2f);

        State = BattleState.PlayerTurn;
        PlayerTurn();
    }
    public void PlayerTurn()
    {
        DialogueText.text = "Choose an action...";
    }

    public void OnLightMeleeAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("LightMelee");
    }
    public void OnLightMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("LightMagic");
    }
    public void OnBuffButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Buff");
    }
   
    public void EnemyTurn()
    {
        DialogueText.text = "Enemy attacks...";
        Enemy_GO.GetComponent<Animator>().SetTrigger("Attack");
    }
    public void EndBattle()
    {
        if (State == BattleState.Won)
        {
            DialogueText.text = "win";
        }
        else if (State == BattleState.Lost)
        {
            DialogueText.text = "lost";
        }
    }
}