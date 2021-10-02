using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{

    public EnemyData enemyData;

    [Header("Info")]
    public string enemyName;
    public EnemyType enemyType;
    public int armor;
    public int damage;
    public int maxHealth;

    public Slider healthSlider;
    public Color armoredColor;

    public GameObject currentArmorDisp;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI enemyNameText;

    [Header("Intents Display")]

    public Image inentImage;
    public TextMeshProUGUI intentAmtText;
    public TextMeshProUGUI armorAmtDisplay;

    public Sprite sprIntentAttack;
    public Sprite sprIntentDefense;
    public Sprite sprIntentBuff;
    public Sprite sprIntentDisable;

    public List<EnemyData.EnemyIntent> immediateIntentList = new List<EnemyData.EnemyIntent>();
    public int immediateIntentStrength;


    [SerializeField]
    private int currentHealth;
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }

    public void Start()
    {
    }

    private void CollectEnemyData()
    {
  
        if (enemyData == null)
        {
            Destroy(this.gameObject);
            return;
        }

        enemyName = enemyData.enemyName;
        enemyType = enemyData.enemyType;

        maxHealth = enemyData.maxHealth;
        damage = enemyData.damage;
        armor = enemyData.armor;

        healthSlider.maxValue = maxHealth;
        enemyNameText.text = enemyName.ToUpper();
        CurrentHealth = maxHealth;
    }

    private void HandleHealth()
    { 
        
    }

}
