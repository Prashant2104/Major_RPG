using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject Opponent;
    public float Speed;
    public float RotSpeed;
    public float Accuracy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        //Opponent = NPC.GetComponent<EnemyAI>().battleSystem.Player_TPC;
        Opponent = NPC.GetComponent<EnemyAI>().GetPlayer();
    }
}