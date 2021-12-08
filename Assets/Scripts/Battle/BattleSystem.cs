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
    PlayerUnits playerUnits;
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
        Player_GO.SetActive(true);

        battleController = Player_GO.GetComponent<PlayerBattleController>();
        playerUnits = Player_GO.GetComponent<PlayerUnits>();
        enemyUnits = Enemy_GO.GetComponent<EnemyAI>();

        Player_TPC.SetActive(false);

        DialogueText.text = "You encountered '" + enemyUnits.name + " '";

        PlayerHUD.SetHUD(playerUnits);
        EnemyHUD.SetHUD(enemyUnits);

        yield return new WaitForSeconds(2f);

        State = BattleState.PlayerTurn;
        PlayerTurn();
    }
    void PlayerTurn()
    {
        DialogueText.text = "Choose an action...";
    }

    public void OnMeleeAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        StartCoroutine(PlayerMelleAttack());
    }
    public void OnMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        StartCoroutine(PlayerMagicAttack());
    }
    public void OnBuffButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        StartCoroutine(PlayerBuff());
    }
    IEnumerator PlayerMelleAttack()
    {
        //bool isDead = enemyUnits.TakeDamage(playerUnits.MeleeDamage);

        yield return new WaitForSeconds(2f);

        EnemyHUD.SetHP(enemyUnits.CurrentHP);

        /*if(isDead)
        {
            State = BattleState.Won;
            EndBattle();
        }
        else
        {
            State = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }*/
    }
    IEnumerator PlayerMagicAttack()
    {
        //bool isDead = enemyUnits.TakeDamage(playerUnits.MagicDamage);

        yield return new WaitForSeconds(2f);

        //EnemyHUD.SetHP(enemyUnits.CurrentHP);

        /*if (isDead)
        {
            State = BattleState.Won;
            EndBattle();
        }
        else
        {
            State = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }*/
    }

    IEnumerator PlayerBuff()
    {
        yield return new WaitForSeconds(2f);
    }
    void EndBattle()
    {
        if(State == BattleState.Won)
        {
            DialogueText.text = "win";
        }
        else if(State == BattleState.Lost)
        {
            DialogueText.text = "lost";
        }
    }
    IEnumerator EnemyTurn()
    {
        DialogueText.text = "Enemy attacks...";
        yield return new WaitForSeconds(1f);

        //bool isDead = playerUnits.TakeDamage(enemyUnits.MeleeDamage);
        //PlayerHUD.SetHP(playerUnits.CurrentHP);

        /*if (isDead)
        {
            State = BattleState.Lost;
            EndBattle();
        }
        else
        {
            State = BattleState.PlayerTurn;
            PlayerTurn();
        }*/
    }
}