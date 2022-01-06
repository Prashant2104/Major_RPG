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

    public bool IsPaused;
    public GameObject PausePanel;

    [SerializeField] int enemyCount;
    [SerializeField] int triggerCount;

    void Awake()
    {
        IsPaused = false;

        ThirdPersonController.SetActive(true);
        Player_Battle.SetActive(false);
        for (int i = 0; i < Potions.Length; i++)
            Potions[i].SetActive(false);

        enemyCount = Enemy.Length;
        for (int i = 0; i < enemyCount; i++)
            Enemy[i].SetActive(false);

        Enemy[0].SetActive(true);

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
    public void PauseMenu()
    {
        if (!battleSystem.isActiveAndEnabled)
        {
            IsPaused = !IsPaused;
            if (IsPaused)
            {
                Time.timeScale = 0f;
                Player_TPC.GetComponent<PlayerManager>().enabled = false;
                PausePanel.SetActive(true);
            }
            if (!IsPaused)
            {
                Time.timeScale = 1f;
                Player_TPC.GetComponent<PlayerManager>().enabled = true;
                PausePanel.SetActive(false);
            }
        }
    }
}