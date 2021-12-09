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

    public float Defence;
    public float MaxHP;
    public float CurrentHP;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        battleSystem = GetComponent<BattleSystem>();
    }

    private void OnEnable()
    {
        this.gameObject.transform.position = PlayerOG.transform.position;
        this.transform.LookAt(Enemy.transform);
    }
}