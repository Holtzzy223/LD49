using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enchant_", menuName = "New Enchantment")]
public class EnchantmentData : ScriptableObject
{
    public string enchantmentName;
    public Sprite enchantmentSprite;
    [TextArea(5,10)]
    public string enchantmentDesc;
    public EnchantmentEffects[] allEnchantmentEffects;

    [System.Serializable]

    public struct EnchantmentEffects
    {
        public Status effect;
        public float effectAmt;

    }
}
