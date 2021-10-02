using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_", menuName = "New enemy")]

public class EnemyData : ScriptableObject
{
    public EnemyType enemyType;
    public string enemyName;
    public int maxHP;
    public int damage;
    public EnemyIntent[] enemyIntents;

    [System.Serializable]
    public struct EnemyIntnet
    {
        public EnemyIntnetType[] intent;
        public int amt;
    }

}
