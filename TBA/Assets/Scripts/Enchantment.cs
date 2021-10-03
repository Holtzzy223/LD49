using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Enchantment : MonoBehaviour
{
    public EnchantmentData enchantmentData;
    public string enchantmentName;
    public Sprite enchantmentSprite;

    [TextArea(5, 10)]
    public string enchantmentDesc;
    public float enchantmentStrength;
    public EnchantmentTypes enchantmentType;

    public int turnsLeft;

    public TextMeshProUGUI enchantmentText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    private void Start()
    {

    }

    private void LoadEnchantmentData()
    {
        enchantmentName = enchantmentData.enchantmentName;
        enchantmentSprite = enchantmentData.enchantmentSprite;
        enchantmentDesc = enchantmentData.enchantmentDesc;

        GetComponent<Image>().sprite = enchantmentSprite;

        enchantmentText.text = enchantmentName;
        titleText.text = enchantmentType.ToString();
        descText.text = enchantmentDesc;

    }
}

