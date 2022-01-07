using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }
public class BattleSystem : MonoBehaviour
{
    public BattleState State;
    public GameManager Manager;

    public GameObject Player_TPC;
    public GameObject Player_GO;
    public GameObject Enemy_GO;

    public GameObject BattleHUD;

    public PlayerBattleHUD PlayerHUD;
    public EnemyBattleHUD EnemyHUD;
    public Inventory inventory;

    public Text DialogueText;
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

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);

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

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(AttackPanel.transform.GetChild(0).gameObject);
    }
    public void OnSpecialChoice()
    {
        ChoicePanel.SetActive(false);
        SpecialPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(SpecialPanel.transform.GetChild(0).gameObject);
    }
    public void OnBackButton()
    {
        AttackPanel.SetActive(false);
        SpecialPanel.SetActive(false);
        ChoicePanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void OnLightMeleeAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("LightMelee");

        AttackPanel.SetActive(false);
        ChoicePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void OnHeavyMeleeAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("HeavyMelee");

        AttackPanel.SetActive(false);
        ChoicePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void OnLightMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("LightMagic");

        AttackPanel.SetActive(false);
        ChoicePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void OnHeavyMagicAttackButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("HeavyMagic");

        AttackPanel.SetActive(false);
        ChoicePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void OnBuffButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Buff");

        SpecialPanel.SetActive(false);
        ChoicePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void OnDefendButton()
    {
        if (State != BattleState.PlayerTurn)
            return;
        if (Player_GO.GetComponent<PlayerBattleController>().MagicDefence + 1 >= Enemy_GO.GetComponent<EnemyAI>().MagicDamage ||
            Player_GO.GetComponent<PlayerBattleController>().MeleeDefence + 1 >= Enemy_GO.GetComponent<EnemyAI>().MeleeDamage)
            return;

        Player_GO.GetComponent<Animator>().SetTrigger("Defend");

        SpecialPanel.SetActive(false);
        ChoicePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void OnHealButton()
    {
        if (State != BattleState.PlayerTurn || inventory.HealPotion < 1)
            return;
        Player_GO.GetComponent<Animator>().SetTrigger("Heal");

        PlayerHUD.SetHUD(battleController);

        SpecialPanel.SetActive(false);
        ChoicePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ChoicePanel.transform.GetChild(0).gameObject);
    }
    public void EnemyTurn()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
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
        Enemy_GO.GetComponent<AudioSource>().Stop();
        DialogueText.text = "You win";
        Enemy_GO.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(0.5f);
        BattleHUD.SetActive(false);
        Player_GO.SetActive(false);
        Player_TPC.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GetComponent<BattleSystem>().enabled = false;

        Player_GO.GetComponent<PlayerBattleController>().MaxHP += 1;
        Player_GO.GetComponent<PlayerBattleController>().CurrentHP += 1;
        Player_GO.GetComponent<PlayerBattleController>().MeleeDam += 0.5f;
        Player_GO.GetComponent<PlayerBattleController>().MeleeDef += 0.5f;
        Player_GO.GetComponent<PlayerBattleController>().MagicDam += 0.5f;
        Player_GO.GetComponent<PlayerBattleController>().MagicDef += 0.5f;
    }
    IEnumerator Lost()
    {
        DialogueText.text = "You Lost";
        Player_GO.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(0.5f);
        BattleHUD.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GetComponent<BattleSystem>().enabled = false;
    }
}