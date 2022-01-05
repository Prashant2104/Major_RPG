using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public BattleSystem battleSystem;
    public GameObject Player;
    private Animator anim;
    public NavMeshAgent agent;
    [SerializeField] float dist;

    [Header("Class")]
    public bool IsHeavy;
    public bool IsMelee;
    public bool IsMagic;

    [Header("Stats")]
    public float MeleeDamage;
    public float MagicDamage;
    public float MeleeDefence;
    public float MagicDefence;

    [Header("Health")]
    public float MaxHP;
    public float CurrentHP;

    [Header("Particle System")]
    public ParticleSystem OnAwake;
    public GameObject LightMagicAttack;
    public GameObject HeavyMagicAttack_Parent;
    public ParticleSystem HeavyMagicAttack;
    public ParticleSystem Defence;
    public ParticleSystem Buff;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(this.transform.position, Player.transform.position));
        dist = Vector3.Distance(this.transform.position, Player.transform.position);
    }
    public GameObject GetPlayer()
    {
        return Player;
    }
    public void InBattle()
    {
        battleSystem.Enemy_GO = this.gameObject;
        battleSystem.enabled = true;
    }
    public bool TakeMeleeDamage(float dmg)
    {
        CurrentHP -= (dmg - MeleeDefence);

        battleSystem.EnemyHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public bool TakeMagicDamage(float dmg)
    {
        CurrentHP -= (dmg - MagicDefence);

        battleSystem.EnemyHUD.SetHP(CurrentHP);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
    public void LightMagicVFX()
    {
        LightMagicAttack.transform.LookAt(battleSystem.Player_GO.transform.position);
        LightMagicAttack.SetActive(true);
    }
    public void HeavyMagicVFX()
    {
        HeavyMagicAttack.Play(true);
    }
    public void DefenceVFX()
    {
        Defence.Play();
    }
    public void BuffVFX()
    {
        Buff.Play();
    }
}