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

        yield return new WaitForSeconds(1f);

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
    public void OnHeavyMeleeAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("HeavyMelee");
    }
    public void OnLightMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("LightMagic");
    }
    public void OnHeavyMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("HeavyMagic");
    }
    public void OnBuffButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Buff");
    }
    public void OnDefendButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Defend");
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
            StartCoroutine(Win());
        }
        else if (State == BattleState.Lost)
        {
            DialogueText.text = "lost";
            StartCoroutine(Lost());
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(Enemy_GO);
        BattleHUD.SetActive(false);
        Player_GO.SetActive(false);
        Player_TPC.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        GetComponent<BattleSystem>().enabled = false;
    }

    IEnumerator Lost()
    {
        yield return new WaitForSeconds(1f);
        Debug.Break();
    }
}