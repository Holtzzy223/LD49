using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public static CombatManager _CombatManInst = CombatManager.instance;
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
    }

    private void Start()
    {
        for (int i = 0; i < enemyIndexData.Count;i++)
        {
            enemyIndex.Add(i);
        }

        for (int i = 0; i < enemyIndex.Count;i++)
        {
            enemyDictionary.Add(i,enemyIndexData[i]);
        }

        int range = Random.Range(0,enemyDictionary.Count);

        SpawnEnemy(enemyDictionary[range]);


    }

    public void SpawnEnemy(EnemyData enemyData)
    {
        GameObject enemyToSpawn = Instantiate(enemyPrefab, spawnPostion);
        Enemy enemy = enemyToSpawn.GetComponent<Enemy>();
        enemy.enemyData = enemyData;
        _CombatManInst.currentEnemy = enemy;

    }
}
