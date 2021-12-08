using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnits : MonoBehaviour
{
    public string UnitName;

    public float MeleeDamage;
    public float MagicDamage;

    public float Defence;
    public float MaxHP;
    public float CurrentHP;

    public bool TakeDamage(float Dmg)
    {
        CurrentHP -= (Dmg - Defence);

        if (CurrentHP <= 0)
            return true;
        else
            return false;
    }
}