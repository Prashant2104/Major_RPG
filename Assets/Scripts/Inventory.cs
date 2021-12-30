using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] Slots;

    public int HealPotion;
    public int HealthPotion;

    public int MeleeDefencePotion;
    public int MagicDefencePotion;

    public int MeleeAttackPotion;
    public int MagicAttackPotion;

    public GameObject Player;

    public void HealAdd()
    {
        HealthPotion++;
        Slots[0].GetComponent<Text>().text = HealPotion.ToString();
    }
    public void HealthAdd()
    {
        HealthPotion++;
        Slots[1].GetComponent<Text>().text = HealthPotion.ToString();
    }
    public void MeleeDefenceAdd()
    {
        MeleeDefencePotion++;
        Slots[2].GetComponent<Text>().text = MeleeDefencePotion.ToString();
    }
    public void MagicDefenceAdd()
    {
        MeleeDefencePotion++;
        Slots[3].GetComponent<Text>().text = MagicDefencePotion.ToString();
    }
    public void MeleeAttackAdd()
    {
        MeleeAttackPotion++;
        Slots[4].GetComponent<Text>().text = MeleeAttackPotion.ToString();
    }
    public void MagicAttackAdd()
    {
        MeleeAttackPotion++;
        Slots[5].GetComponent<Text>().text = MagicAttackPotion.ToString();
    }

    public void HealButton()
    {
        Player.GetComponent<PlayerBattleController>().CurrentHP += 15;

        if (Player.GetComponent<PlayerBattleController>().CurrentHP > Player.GetComponent<PlayerBattleController>().MaxHP)
        {
            Player.GetComponent<PlayerBattleController>().CurrentHP = Player.GetComponent<PlayerBattleController>().MaxHP;
        }
    }
    public void HealthButton()
    {
        Player.GetComponent<PlayerBattleController>().MaxHP += 10;
        Player.GetComponent<PlayerBattleController>().CurrentHP += 10;
    }
    public void MeleeDefenceButton()
    {
        Player.GetComponent<PlayerBattleController>().MeleeDefence += 2;
    }
    public void MagicDefenceButton()
    {
        Player.GetComponent<PlayerBattleController>().MagicDefence += 1.5f;
    }
    public void MeleeAttackButton()
    {
        Player.GetComponent<PlayerBattleController>().MeleeDamage += 2;
    }
    public void MagicAttackButton()
    {
        Player.GetComponent<PlayerBattleController>().MagicDamage += 1.5f;
    }
}