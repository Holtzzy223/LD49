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
    public Image armorImage;
    public TextMeshProUGUI actionsText;
    public GameObject rewardContainer;
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
  
       actionsText.text = string.Format("Actions: <color=#e6d64c>{1}</color>/<color=#e6d64c>{0}</color>", CardManager.instance.actionsAtStart,CardManager.instance.currentActions);
    
    }

}
