using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleController : MonoBehaviour
{
    public GameObject PlayerOG;
    public GameObject Enemy;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        this.gameObject.transform.position = PlayerOG.transform.position;
        this.transform.LookAt(Enemy.transform);
    }
}