using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class UIManager : MonoBehaviour 
{
    public static UIManager instance;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI actionsText;

    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    public void UpdateDisplay()
    {
        //todo : update with hex codes
        /*
        var _cmInst = CombatManager.instance;
        healthText.text = string.Format("{0}<color=#>/</color>{1}",_cmInst.CurrentHealth,_cmInst.maxHealth);
        armorText.text = string.Format("Armor: {0}",_cmInst.currentArmor);
        actionsText.text = string.Format("Acions: <color=#>{0}</color><color=#>{1}</color>",CardManager.instance.actionsAtStart,CardManager.instance.currentActions);
    */
    }

}
