using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class UIManager : MonoBehaviour 
{
    public static UIManager instance;

    public Slider healthSlider;
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
    private void Start()
    {
        healthSlider.maxValue = CombatManager.instance.maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = CombatManager.instance.maxHealth;
    }
    public void UpdateDisplay()
    {
        //todo : update with hex codes
        
       var _cmInst = CombatManager.instance;
       healthSlider.value = _cmInst.CurrentHealth;
      // armorText.text = string.Format("Armor: {0}",_cmInst.currentArmor);
      // actionsText.text = string.Format("Acions: <color=#>{0}</color><color=#>{1}</color>",CardManager.instance.actionsAtStart,CardManager.instance.currentActions);
    
    }

}
