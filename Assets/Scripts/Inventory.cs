using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text[] Slots;

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
        Slots[0].text = HealPotion.ToString();
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
    }
    public void MagicDefenceAdd()
    {
        MagicDefencePotion++;
        Player.GetComponent<PlayerBattleController>().MagicDefence += 1.5f;
    }
    public void MeleeAttackAdd()
    {
        MeleeAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MeleeDamage += 2;
    }
    public void MagicAttackAdd()
    {
        MagicAttackPotion++;
        Player.GetComponent<PlayerBattleController>().MagicDamage += 1.5f;
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