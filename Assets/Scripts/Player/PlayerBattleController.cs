using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour
{
    public GameObject PlayerOG;
    public GameObject Enemy;
    public BattleSystem battleSystem;

    private Animator anim;

    [Header("Battle Stats")]
    public float MeleeDamage;
    public float MagicDamage;
    public float MeleeDefence;
    public float MagicDefence;

    [Header("Actual Stats")]
    public float MeleeDam;
    public float MagicDam;
    public float MeleeDef;
    public float MagicDef;

    [Header("Health")]
    public float MaxHP;
    public float CurrentHP;

    [Header("Particle System")]
    public ParticleSystem OnAwake;
    public ParticleSystem MeleeLightAttack;
    public ParticleSystem MeleeHeavyAttack;
    public ParticleSystem MagicLightAttack;
    public ParticleSystem MagicHeavyAttack;
    public ParticleSystem Defence;
    public ParticleSystem Buff;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //battleSystem = GetComponent<BattleSystem>();
    }

    private void OnEnable()
    {
        MeleeDamage = MeleeDam;
        MeleeDefence = MeleeDef;
        MagicDamage = MagicDam;
        MagicDefence = MagicDef;

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
    public void HUD()
    {
        battleSystem.PlayerHUD.SetHP(CurrentHP);
    }
}