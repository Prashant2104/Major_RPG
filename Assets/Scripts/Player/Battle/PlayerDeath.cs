using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : PlayerUnits
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.transform.localScale = Vector3.Lerp(Player.transform.localScale, Vector3.zero, 0.9f * Time.deltaTime);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.gameObject.SetActive(false);
    }
}