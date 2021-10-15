using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public static CombatManager _CombatManInst;
    public Transform spawnPostion;
    public GameObject enemyPrefab;
    [Header("Enemy Data")]

    public List<int> enemyIndex = new List<int>();
    public List<EnemyData> enemyIndexData = new List<EnemyData>();
    public Dictionary<int, EnemyData> enemyDictionary = new Dictionary<int, EnemyData>();
    private void Awake()
    {
        
        if (instance != null & instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        for (int i = 0; i < enemyIndexData.Count; i++)
        {
            enemyIndex.Add(i);
        }

        for (int i = 0; i < enemyIndex.Count; i++)
        {
            enemyDictionary.Add(i, enemyIndexData[i]);
        }
    }

    private void Start()
    {
        _CombatManInst = CombatManager.instance;
    }

    public void SpawnEnemy()
    {
        int rand = Random.Range(0, enemyDictionary.Count);
        GameObject enemyToSpawn = Instantiate(enemyPrefab, spawnPostion);
        Enemy enemy = enemyToSpawn.GetComponent<Enemy>();
        enemy.enemyData = enemyDictionary[rand];
        _CombatManInst.currentEnemy = enemy;
        GameManager.instance.ChangeState(GameState.COMBAT);
    }

    public void NextIntent(Enemy enemy)
    {
      int rand = Random.Range(0, enemy.enemyData.enemyIntents.Length);
     
      enemy.intentList.Clear();
      EnemyData.EnemyIntent intent = enemy.enemyData.enemyIntents[rand];
     
      //loop through and add
      for (int i = 0; i < intent.intent.Length; i++)
      {
          enemy.intentList.Add(intent);
         
      }
     
        switch (enemy.intentList[0].intent[0])
        {
          case EnemyIntentType.ATTACK:
              enemy.intentImage.sprite = enemy.sprIntentAttack;
              break;
          case EnemyIntentType.ARMOR:
              enemy.intentImage.sprite = enemy.sprIntentArmor;
             
              break;
          case EnemyIntentType.ABILITY:
              enemy.intentImage.sprite = enemy.sprIntentAbility;
              break;
          case EnemyIntentType.BUFF:
              enemy.intentImage.sprite = enemy.sprIntentBuff;
              break;
          case EnemyIntentType.DEBUFF:
              enemy.intentImage.sprite = enemy.sprIntentDebuff;
              break;
          case EnemyIntentType.FLEE:
              enemy.intentImage.sprite = enemy.sprIntentFlee;
              break;
        }
    }
    public IEnumerator TakeTurn(Enemy enemy)
    {

        for (int i = 0; i <= enemy.intentList.Count - 1; i++)
        {
            yield return new WaitForSeconds(0.5f);
            switch (enemy.intentList[i].intent[i])
            {
                case EnemyIntentType.ATTACK:
                    CombatManager.instance.TakeDamage(enemy.damage); 
                    break;
                case EnemyIntentType.ARMOR:
                    enemy.BuffArmor(GetBuffAmount(1,4));
                    break;
                case EnemyIntentType.ABILITY:
                    //unstable shit
                    break;
                case EnemyIntentType.BUFF:
                    RollBuff(enemy);
                    break;
                case EnemyIntentType.DEBUFF:
                    enemy.DeBuff(enemy.armor, GetBuffAmount());
                    break;
                case EnemyIntentType.FLEE:
                    GameManager.instance.ChangeState(GameState.ENDMATCH);
                    break;
            }
            break;
        }
        EndTurn();
       
    }
    private void RollBuff(Enemy enemy)
    {
        
        int roll = -1;
        roll = Random.Range(0,4);
        Debug.Log(roll);
        switch (roll)
        {
            case 0://armor
                enemy.BuffArmor(GetBuffAmount());
                break;
            case 1://health
                enemy.Heal(GetBuffAmount());
                break;
            case 2://damage
                enemy.BuffDamage(GetBuffAmount());
                break;
            case 3://broad?
                var buffAll = BuffAllStats(enemy);
                StartCoroutine(buffAll);
                break;
        }
    }
    IEnumerator BuffAllStats(Enemy enemy)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    enemy.BuffArmor(GetBuffAmount());
                    break;
                case 1:
                    enemy.BuffDamage(GetBuffAmount());
                    break;
                case 2:
                    enemy.Heal(GetBuffAmount());
                    break;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
    private int GetBuffAmount(int min = 1,int max = 10)
    {
        int buffAmt = Random.Range(min,max);
        Debug.Log("Buff Amount: " + buffAmt);
        return buffAmt;
    }

    public void EndTurn()
    {
        //todo:remove player effects at emd of turn  

        CardManager.instance.StartNewTurn();

    }

}
