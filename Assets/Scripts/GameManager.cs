using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player_TPC;
    public GameObject ThirdPersonController;
    public GameObject Player_Battle;
    public GameObject[] Enemy;
    public GameObject[] Potions;
    public BattleSystem battleSystem;

    [SerializeField] int enemyCount;
    [SerializeField] int triggerCount;

    void Awake()
    {
        ThirdPersonController.SetActive(true);
        Player_Battle.SetActive(false);
        for (int i = 0; i < Potions.Length; i++)
            Potions[i].SetActive(false);

        enemyCount = Enemy.Length;
        for (int i = 0; i < enemyCount; i++)
            Enemy[i].SetActive(false);

        //Enemy[0].SetActive(true);

        battleSystem.enabled = false;
    }

    public void EnemyCounter()
    {
        enemyCount--;
    }

    public void TriggerEnter()
    {
        triggerCount++;

        Enemy[triggerCount].SetActive(true);
        Potions[triggerCount-1].SetActive(true);
    }
}