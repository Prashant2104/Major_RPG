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
    public Inventory inventory;

    public Text DialogueText;
    public Button Attack, Special;
    public GameObject ChoicePanel, AttackPanel, SpecialPanel;

    PlayerBattleController battleController;
    EnemyAI enemyUnits;

    private void OnEnable()
    {
        State = BattleState.Start;
        BattleHUD.SetActive(true);
        ChoicePanel.SetActive(true);
        AttackPanel.SetActive(false);
        SpecialPanel.SetActive(false);
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
    public void OnAttackChoice()
    {
        ChoicePanel.SetActive(false);
        AttackPanel.SetActive(true);
    }
    public void OnSpecialChoice()
    {
        ChoicePanel.SetActive(false);
        SpecialPanel.SetActive(true);
    }
    public void OnLightMeleeAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("LightMelee");

        ChoicePanel.SetActive(true);
        AttackPanel.SetActive(false);
    }
    public void OnHeavyMeleeAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("HeavyMelee");

        ChoicePanel.SetActive(true);
        AttackPanel.SetActive(false);
    }
    public void OnLightMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("LightMagic");

        ChoicePanel.SetActive(true);
        AttackPanel.SetActive(false);
    }
    public void OnHeavyMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("HeavyMagic");

        ChoicePanel.SetActive(true);
        AttackPanel.SetActive(false);
    }
    public void OnBuffButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Buff");

        ChoicePanel.SetActive(true);
        SpecialPanel.SetActive(false);
    }
    public void OnDefendButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Defend");

        ChoicePanel.SetActive(true);
        SpecialPanel.SetActive(false);
    }
    public void OnHealButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Heal");
        inventory.HealButton();

        ChoicePanel.SetActive(true);
        SpecialPanel.SetActive(false);
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
            Lost();
        }
    }

    IEnumerator Win()
    {
        DialogueText.text = "You win";
        Enemy_GO.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(0.5f);
        BattleHUD.SetActive(false);
        Player_GO.SetActive(false);
        Player_TPC.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GetComponent<BattleSystem>().enabled = false;
    }
    void Lost()
    {
        Player_GO.GetComponent<Animator>().SetTrigger("Death");
    }
}