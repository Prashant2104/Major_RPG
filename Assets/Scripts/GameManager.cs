using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player_TPC;
    public GameObject ThirdPersonController;
    public GameObject Player_Battle;
    public GameObject[] Enemy;
    public BattleSystem battleSystem;

    [SerializeField] int enemyCount;

    void Start()
    {
        ThirdPersonController.SetActive(true);
        Player_Battle.SetActive(false);

        battleSystem.enabled = false;

        enemyCount = Enemy.Length;
        for (int i = 0; i < enemyCount; i++)
            Enemy[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}