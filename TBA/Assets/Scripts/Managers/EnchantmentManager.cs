using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantmentManager : MonoBehaviour
{
    public static EnchantmentManager instance;
    public CombatManager combatManInst;
    public GameObject enchantPrefab;
    public Transform enchantContainer;

    public List<EnchantmentTypes> startCombatEnchants = new List<EnchantmentTypes>();
    public List<EnchantmentTypes> allCurrentEnchants = new List<EnchantmentTypes>();

    public Dictionary<EnchantmentTypes, EnchantmentData> enchantDict = new Dictionary<EnchantmentTypes, EnchantmentData>();

    public EnchantmentData balanceBeamSO;
    public EnchantmentData scaleSO;

    private void Awake()
    {
        combatManInst = CombatManager.instance;
        if (instance != null & instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        InitEnchantDictionary();
    }

    private void InitEnchantDictionary()
    {
        allCurrentEnchants.Clear();

        enchantDict.Add(EnchantmentTypes.BALANCE_BEAM, balanceBeamSO);
        enchantDict.Add(EnchantmentTypes.SCALE, scaleSO);

    }

    public EnchantmentData GetEnchantmentFromType(EnchantmentTypes type)
    {
        if (!HasEnchantment(type))
        {
            Debug.LogError(string.Format("{0} is not a valid entry in the enchantment dictionary", type.ToString()));
            return null;
        }

        return enchantDict[type];
    }

    public void AddEnchantment(EnchantmentTypes type)
    {
        if (!allCurrentEnchants.Contains(type))
        {
            GameObject gameObject = Instantiate(enchantPrefab, enchantContainer);
            gameObject.GetComponent<Enchantment>().enchantmentData = GetEnchantmentFromType(type);

        }
    }

    public bool HasEnchantment(EnchantmentTypes type)
    {
        return allCurrentEnchants.Contains(type);
    }
    public void ActivateTrinket(EnchantmentTypes type)
    {
        //allenchantments
        switch (type)
        {
            case EnchantmentTypes.BALANCE_BEAM:
                combatManInst.AddStatus(StatusType.EQUILIBRIUM, 1);
                break;
            case EnchantmentTypes.SCALE:
                break;
        }
    }
}
