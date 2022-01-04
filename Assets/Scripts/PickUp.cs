using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Inventory inventory;

    [SerializeField] bool healPotion;
    [SerializeField] bool healthPotion;

    [SerializeField] bool meleeDefencePotion;
    [SerializeField] bool magicDefencePotion;

    [SerializeField] bool meleeAttackPotion;
    [SerializeField] bool magicAttackPotion;

    private void FixedUpdate()
    {
        //this.transform.Rotate(new Vector3(10, 75, 0) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(healPotion)
            {
                inventory.HealAdd();
            }
            if(healthPotion)
            {
                inventory.HealthAdd();
            }
            if(meleeDefencePotion)
            {
                inventory.MeleeDefenceAdd();
            }
            if(magicDefencePotion)
            {
                inventory.MagicDefenceAdd();
            }
            if(meleeAttackPotion)
            {
                inventory.MeleeAttackAdd();
            }
            if(magicAttackPotion)
            {
                inventory.MagicAttackAdd();
            }

            this.gameObject.SetActive(false);
        }
    }
}
/*
Heal Potion
Health Increase Potion
Magic Defence Increase Potion
Magic Attack Increase Potion
Melee Defence Increase Potion
Melee Attack Increase Potion
*/