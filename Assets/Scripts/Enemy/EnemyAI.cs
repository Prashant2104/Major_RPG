using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public BattleSystem battleSystem;
    public GameObject Player;

    public bool IsHeavy;
    public bool IsMelee;
    public bool IsMagic;

    public float MeleeDamage;
    public float MagicDamage;

    public float MeleeDefence;
    public float MagicDefence;

    public float MaxHP;
    public float CurrentHP;

    private Animator anim;
    public NavMeshAgent agent;
    [SerializeField] float dist;

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
}