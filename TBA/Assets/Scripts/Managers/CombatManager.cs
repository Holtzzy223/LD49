using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private int turnCount = 0;
   
    public int TurnCounter { get { return turnCount; } set { turnCount = value; } }
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value;UpdateHealthDisplay(); } }
    public CardManager _cardManagerInst;
    public StatusManager _statusManagerInst;

    public List<StatusType> currentStatuses = new List<StatusType>();
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
        _cardManagerInst = CardManager.instance;
        _statusManagerInst = StatusManager.instance;
        maxHealth = initialHealth;
        currentHealth = maxHealth;

        UIManager.instance.UpdateDisplay();
       
        StartCoroutine(EnchantmentManager.instance.CheckForStartEnchantments());
    }
    private void UpdateHealthDisplay()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UIManager.instance.UpdateDisplay();
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public void DealDamage(int damage,Enemy enemy)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
      
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
    public void SetStat(int statToBuff, int amt)
    {
        statToBuff = amt;
        statToBuff = Mathf.Clamp(statToBuff, 0, 999);
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
        statToDebuff =  Mathf.Clamp(statToDebuff,0,999);
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

    public void AddStatus(StatusType status, int duration)
    {
        if (!currentStatuses.Contains(status))
        {
            _statusManagerInst.AddStatus(CurrentTurn.PLAYER, status);
            _statusManagerInst.CreateStatus(status, false);

        }
        else 
        {
            for(int i = 0; i < currentStatuses.Count;i++)
            {
                if (currentStatuses[i]== status)
                { 
                  //add duration
                }
            }
        }
        _statusManagerInst.UpdateStatusUI();
    }

}