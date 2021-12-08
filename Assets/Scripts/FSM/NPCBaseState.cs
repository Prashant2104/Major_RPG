using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseState : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject Opponent;
    public float Speed;
    public float RotSpeed;
    public float Accuracy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        Opponent = NPC.GetComponent<TankAI>().GetPlayer();
    }
}