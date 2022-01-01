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
        HealPotion++;
        Slots[0].GetComponent<Text>().text = HealPotion.ToString();
    }
    public void HealthAdd()
    {
        HealthPotion++;
        Player.GetComponent<PlayerBattleController>().MaxHP += 10;
        Player.GetComponent<PlayerBattleController>().CurrentHP += 10;
    }
    public void MeleeDefenceAdd()
    {
        MeleeDefencePotion++;
        Player.GetComponent<PlayerBattleController>().MeleeDefence += 2;
    }
    public void MagicDefenceAdd()
    {
        MeleeDefencePotion++;
        Player.GetComponent<PlayerBattleController>().MagicDefence += 1.5f;
    }
    public void MeleeAttackAdd()
    {
        MeleeAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MeleeDamage += 2;
    }
    public void MagicAttackAdd()
    {
        MeleeAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MagicDamage += 1.5f;
    }

    public void HealButton()
    {
        Player.GetComponent<PlayerBattleController>().CurrentHP += 15;
        HealPotion--;

        if (Player.GetComponent<PlayerBattleController>().CurrentHP > Player.GetComponent<PlayerBattleController>().MaxHP)
        {
            Player.GetComponent<PlayerBattleController>().CurrentHP = Player.GetComponent<PlayerBattleController>().MaxHP;
        }
    }
}