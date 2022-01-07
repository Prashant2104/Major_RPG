using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameManager Manager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Exit"))
                FindObjectOfType<ProgressSceneLoader>().LoadScene("Dungeon2");
            if(this.gameObject.CompareTag("GameOver"))

            Manager.TriggerEnter();
            this.gameObject.SetActive(false);
        }
    }
}