using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text[] Slots;
    public GameObject StatsPanel;
    public bool ShowStats;

    public int HealPotion;
    public int HealthPotion;

    public int MeleeDefencePotion;
    public int MagicDefencePotion;

    public int MeleeAttackPotion;
    public int MagicAttackPotion;

    public GameObject Player;

    //UIControl inputs;

    private void Start()
    {
        StatsPanel.SetActive(false);
    }
    //private void OnEnable()
    //{
    //    if(inputs == null)
    //    {
    //        inputs = new UIControl();

    //        //inputs.General.Stats.performed += i => ShowStats = true;
    //        //inputs.General.Stats.canceled += i => ShowStats = false;

    //        //playerControls.PlayerActions.Sprint.performed += i => SprintInput = true;
    //        //playerControls.PlayerActions.Sprint.canceled += i => SprintInput = false;
    //    }
    //}
    private void Update()
    {

        if (Input.GetKey(KeyCode.P))
            ShowStats = true;
        else
            ShowStats = false;

        if (ShowStats)
        {
            StatsPanel.SetActive(true);
            Slots[0].text = "X" + HealPotion;
            Slots[1].text = Player.GetComponent<PlayerBattleController>().CurrentHP + "/" + Player.GetComponent<PlayerBattleController>().MaxHP;            
            Slots[2].text = Player.GetComponent<PlayerBattleController>().MeleeDamage.ToString();
            Slots[3].text = Player.GetComponent<PlayerBattleController>().MagicDamage.ToString();
            Slots[4].text = Player.GetComponent<PlayerBattleController>().MeleeDefence.ToString();
            Slots[5].text = Player.GetComponent<PlayerBattleController>().MagicDefence.ToString();
        }
        else
            StatsPanel.SetActive(false);
    }

    public void HealAdd()
    {
        HealPotion++;
        Slots[0].text = "X" + HealPotion;
    }
    public void HealthAdd()
    {
        HealthPotion++;
        Player.GetComponent<PlayerBattleController>().MaxHP += 5;
        Player.GetComponent<PlayerBattleController>().CurrentHP += 5;
        Slots[1].text = Player.GetComponent<PlayerBattleController>().CurrentHP + "/" + Player.GetComponent<PlayerBattleController>().MaxHP;
    }
    public void MeleeDefenceAdd()
    {
        MeleeDefencePotion++;
        Player.GetComponent<PlayerBattleController>().MeleeDefence += 2;
        Slots[2].text = Player.GetComponent<PlayerBattleController>().MeleeDefence.ToString();
    }
    public void MagicDefenceAdd()
    {
        MagicDefencePotion++;
        Player.GetComponent<PlayerBattleController>().MagicDefence += 1.5f;
        Slots[3].text = Player.GetComponent<PlayerBattleController>().MagicDefence.ToString();
    }
    public void MeleeAttackAdd()
    {
        MeleeAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MeleeDamage += 2;
        Slots[4].text = Player.GetComponent<PlayerBattleController>().MeleeDamage.ToString();
    }
    public void MagicAttackAdd()
    {
        MagicAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MagicDamage += 1.5f;
        Slots[5].text = Player.GetComponent<PlayerBattleController>().MagicDamage.ToString();
    }

    public void HealButton()
    {
        if(HealPotion >= 1)
        {
            Player.GetComponent<PlayerBattleController>().CurrentHP += 15;
            //Player.GetComponent<PlayerBattleController>().SetHUD();
            HealPotion--;

            if (Player.GetComponent<PlayerBattleController>().CurrentHP > Player.GetComponent<PlayerBattleController>().MaxHP)
            {
                Player.GetComponent<PlayerBattleController>().CurrentHP = Player.GetComponent<PlayerBattleController>().MaxHP;
            }
        }
    }
}