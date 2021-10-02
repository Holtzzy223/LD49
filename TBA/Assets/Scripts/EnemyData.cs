using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_", menuName = "New enemy")]

public class EnemyData : ScriptableObject
{
    public EnemyType enemyType;
    public string enemyName;
    public int maxHealth;
    public int damage;
    public int armor;
    public EnemyIntent[] enemyIntents;

    [System.Serializable]
    public struct EnemyIntent
    {
        public EnemyIntentType[] intent;
        public int amt;
    }

}