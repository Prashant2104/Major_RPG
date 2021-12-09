using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public BattleSystem battleSystem;
    public GameObject Player;
    public bool IsHeavy;

    public float MeleeDamage;
    public float MagicDamage;

    public float Defence;
    public float MaxHP;
    public float CurrentHP;

    private Animator anim;
    [SerializeField] float dist;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
    public bool TakeDamage(float dmg)
    {
        CurrentHP -= (dmg - Defence);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
}