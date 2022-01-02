using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour
{
    public GameObject PlayerOG;
    public GameObject Enemy;

    public BattleSystem battleSystem;

    public float MeleeDamage;
    public float MagicDamage;

    public float MeleeDefence;
    public float MagicDefence;

    public float MaxHP;
    public float CurrentHP;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //battleSystem = GetComponent<BattleSystem>();
    }

    private void OnEnable()
    {
        this.gameObject.transform.position = PlayerOG.transform.position;
        this.transform.LookAt(Enemy.transform);
    }
    public bool TakeMeleeDamage(float Dmg)
    {
        CurrentHP -= (Dmg - MeleeDefence);

        battleSystem.PlayerHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public bool TakeMagicDamage(float Dmg)
    {
        CurrentHP -= (Dmg - MagicDefence);

        battleSystem.PlayerHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public void SetHUD()
    {
        battleSystem.PlayerHUD.SetHP(CurrentHP);
    }
}