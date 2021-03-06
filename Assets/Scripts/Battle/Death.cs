using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : EnemyUnits
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisEnemy.transform.localScale = Vector3.Lerp(ThisEnemy.transform.localScale, Vector3.zero, 1.1f * Time.deltaTime);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisEnemy.GetComponent<AudioSource>().Stop();
        ThisEnemy.gameObject.SetActive(false);
    }
}