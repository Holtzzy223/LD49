using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;

    public Enemy currentEnemy;
    public int initialHealth = 25;
    public int maxHealth;
    public int currentArmor = 0;
    public int currentStrength = 1;
    [SerializeField]
    private int currentHealth;
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value;UpdateHealthDisplay(); } }
    public CardManager _cardManagerInst;

    private void Awake()
    {
        _cardManagerInst = CardManager.instance;
        if (instance != null & instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        maxHealth = initialHealth;
        currentHealth = maxHealth;

        UIManager.instance.UpdateDisplay();
    }
    private void UpdateHealthDisplay()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UIManager.instance.UpdateDisplay();
    }


    public void DealDamage(int damage, Card card)
    {
        DiscardCard(card);
    }

    public void TakeDamage(int damage)
    {
        damage -= Mathf.RoundToInt( currentArmor * 0.5f);
        if (damage > 0)
        {
            currentHealth -= damage;
        }
        UpdateHealthDisplay();
    }

    public void Heal(int amtToHeal)
    {
        currentHealth += amtToHeal;
        UpdateHealthDisplay();
    }

    public void BuffStat(int statToBuff,int buffAmt, Card card = null)
    {
        statToBuff += buffAmt;
        Mathf.Clamp(statToBuff,0,999);
        DiscardCard(card);
        UIManager.instance.UpdateDisplay();
    }

    public void DeBuff(int statToDebuff, int debuffAmt, Card card = null)
    {
        statToDebuff -= debuffAmt;
        Mathf.Clamp(statToDebuff,0,999);
        DiscardCard(card);
        UIManager.instance.UpdateDisplay();
    }
    private void DiscardCard(Card card)
    {
        if (card != null)
        {
            _cardManagerInst.DiscardCard(card);
        }
        _cardManagerInst.UpdateDisplay();
    }
}