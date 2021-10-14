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
    public Image healthSliderFill;
    public Color armoredColor;

    public GameObject currentArmorDisp;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI enemyNameText;
    public SpriteRenderer enemyImageRender;
    public Sprite enemyImage;
    [Header("Intents Display")]

    public Image intentImage;
    public TextMeshProUGUI intentAmtText;
    public TextMeshProUGUI armorAmtDisplay;

    public Sprite sprIntentAttack;
    public Sprite sprIntentArmor;
    public Sprite sprIntentAbility;
    public Sprite sprIntentBuff;
    public Sprite sprIntentDebuff;
    public Sprite sprIntentFlee;

    public List<EnemyData.EnemyIntent> intentList = new List<EnemyData.EnemyIntent>();
    public int immediateIntentStrength;


    [SerializeField]
    private int currentHealth;
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }

    public List<StatusType> currentStatuses = new List<StatusType>();
    public static StatusManager _statusManagerInst;
    public Transform enemyStatusContainer;
    private void Awake()
    {
       
    }
    public void Start()
    {
        _statusManagerInst = StatusManager.instance;
        StatusManager.instance.enemyStatusContainer = enemyStatusContainer;
        CollectEnemyData();
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
        enemyImage = enemyData.enemyImage;
        enemyImageRender.sprite = enemyImage;
        maxHealth = enemyData.maxHealth;
        damage = enemyData.damage;
        armor = enemyData.armor;
        for (int i = 0; i < enemyData.enemyIntents.Length; i++)
        {
            intentList.Add(enemyData.enemyIntents[i]);
        }
        healthSlider.maxValue = maxHealth;
      //  enemyNameText.text = enemyName.ToUpper();
        CurrentHealth = maxHealth;
        HandleHealth();
    }

    private void HandleHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
        if (currentHealth <= 0)
        {

            CardManager.instance.DiscardAllCards();
            GameManager.instance.ChangeState(GameState.ENDMATCH);
           
            Destroy(this.gameObject);
        }

        healthSlider.value = currentHealth;
        //healthText.text = string.Format("{0}/{1}", currentHealth,maxHealth);

        ArmorCheck();
    }
    public void ArmorCheck()
    {
        armor = Mathf.Clamp(armor, 0, 999);
        if (armor <= 0)
        {
            healthSliderFill.color = Color.red;
            currentArmorDisp.SetActive(false);
        }
    }

    public void DealDamage(int damage, CombatManager target)
    {
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        damage -= Mathf.RoundToInt(armor * 0.5f);
        if (damage > 0)
        {
            currentHealth -= damage;
        }
        HandleHealth();
    }

    public void Heal(int amtToHeal)
    {
        currentHealth += amtToHeal;
        HandleHealth();
    }

    public void BuffStat(int statToBuff, int buffAmt, Enemy enemy = null)
    {

        statToBuff += buffAmt;
        statToBuff = Mathf.Clamp(statToBuff, 0, 999);
        UIManager.instance.UpdateDisplay();
    }

    public void DeBuff(int statToDebuff, int debuffAmt, Card card = null)
    {
        statToDebuff -= debuffAmt;
        statToDebuff = Mathf.Clamp(statToDebuff, 0, 999);
        UIManager.instance.UpdateDisplay();
    }

    public void OnTurnEnd()
    {
        intentList.Clear();

        EnemyManager.instance.NextIntent(this);
    }

    public void AddStatus(StatusType status, int duration)
    {
        if (!currentStatuses.Contains(status))
        {
            _statusManagerInst.AddStatus(CurrentTurn.ENEMY, status);
            _statusManagerInst.CreateStatus(status, false);

        }
        else
        {
            for (int i = 0; i < currentStatuses.Count; i++)
            {
                if (currentStatuses[i] == status)
                {
                    //add duration
                }
            }
        }
        _statusManagerInst.UpdateStatusUI();
    }

}
