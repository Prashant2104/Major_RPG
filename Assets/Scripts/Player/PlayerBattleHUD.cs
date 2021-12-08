using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleHUD : MonoBehaviour
{
    public Text Name;
    public Slider Health;

    public void SetHUD(PlayerUnits unit)
    {
        Name.text = unit.UnitName;
        Health.maxValue = unit.MaxHP;
        Health.value = unit.CurrentHP;
    }
    public void SetHP(float hp)
    {
        Health.value = hp;
    }
}
