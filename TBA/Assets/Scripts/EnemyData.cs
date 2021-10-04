using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Enemy_", menuName = "New enemy")]

public class EnemyData : ScriptableObject
{
    public EnemyType enemyType;
    public string enemyName;
    public int maxHealth;
    public int damage;
    public int armor;
    public EnemyIntent[] enemyIntents;
    public Sprite enemyImage;
    [System.Serializable]
    public struct EnemyIntent
    {
        public EnemyIntentType[] intent;
        public int amt;
    }

}
