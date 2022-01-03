using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text[] Slots;
    public GameObject StatsPanel;
    public Slider HealthBar;

    public int HealPotion;
    public int HealthPotion;

    public int MeleeDefencePotion;
    public int MagicDefencePotion;

    public int MeleeAttackPotion;
    public int MagicAttackPotion;

    public GameObject Player;

    ThirdPersonPlayerController playerControls;

    private void Start()
    {
        StatsPanel.SetActive(false);
        Slots[0].text = "X" + HealPotion;
        Slots[1].text = Player.GetComponent<PlayerBattleController>().CurrentHP + "/" + Player.GetComponent<PlayerBattleController>().MaxHP;
        HealthBar.value = Player.GetComponent<PlayerBattleController>().CurrentHP;
        HealthBar.maxValue = Player.GetComponent<PlayerBattleController>().MaxHP;
        Slots[2].text = Player.GetComponent<PlayerBattleController>().MeleeDam.ToString();
        Slots[3].text = Player.GetComponent<PlayerBattleController>().MagicDam.ToString();
        Slots[4].text = Player.GetComponent<PlayerBattleController>().MeleeDef.ToString();
        Slots[5].text = Player.GetComponent<PlayerBattleController>().MagicDef.ToString();
    }
    public void EnableStats()
    {
        StatsPanel.SetActive(true);
        Slots[0].text = "X" + HealPotion;
        Slots[1].text = Player.GetComponent<PlayerBattleController>().CurrentHP + "/" + Player.GetComponent<PlayerBattleController>().MaxHP;
        HealthBar.value = Player.GetComponent<PlayerBattleController>().CurrentHP;
        HealthBar.maxValue = Player.GetComponent<PlayerBattleController>().MaxHP;
        Slots[2].text = Player.GetComponent<PlayerBattleController>().MeleeDam.ToString();
        Slots[3].text = Player.GetComponent<PlayerBattleController>().MagicDam.ToString();
        Slots[4].text = Player.GetComponent<PlayerBattleController>().MeleeDef.ToString();
        Slots[5].text = Player.GetComponent<PlayerBattleController>().MagicDef.ToString();
    }
    public void DisableStats()
    {
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
        Player.GetComponent<PlayerBattleController>().MeleeDef += 2;
        Slots[2].text = Player.GetComponent<PlayerBattleController>().MeleeDef.ToString();
    }
    public void MagicDefenceAdd()
    {
        MagicDefencePotion++;
        Player.GetComponent<PlayerBattleController>().MagicDef += 1.5f;
        Slots[3].text = Player.GetComponent<PlayerBattleController>().MagicDef.ToString();
    }
    public void MeleeAttackAdd()
    {
        MeleeAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MeleeDam += 2;
        Slots[4].text = Player.GetComponent<PlayerBattleController>().MeleeDam.ToString();
    }
    public void MagicAttackAdd()
    {
        MagicAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MagicDam += 1.5f;
        Slots[5].text = Player.GetComponent<PlayerBattleController>().MagicDam.ToString();
    }

    public void HealButton()
    {
        if(HealPotion >= 1)
        {
            Player.GetComponent<PlayerBattleController>().CurrentHP += 15;
            HealPotion--;

            if (Player.GetComponent<PlayerBattleController>().CurrentHP > Player.GetComponent<PlayerBattleController>().MaxHP)
            {
                Player.GetComponent<PlayerBattleController>().CurrentHP = Player.GetComponent<PlayerBattleController>().MaxHP;
            }

            Player.GetComponent<PlayerBattleController>().HUD();
        }
    }
}