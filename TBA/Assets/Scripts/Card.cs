using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using TMPro;
using System;
public class Card :MonoBehaviour, IPointerClickHandler
{
    
    public CardData cardData;

    [Header("Card Description")]
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardFlavorText;
    public TextMeshProUGUI cardDescText;
    public TextMeshProUGUI cardTypeText;
    public TextMeshProUGUI cardActionsText;

    [Header("Card Stats")]
    public string cardName;
    public string cardDesc;
    public string cardFlavor;
    public CardTypes cardType;
    public int cardActions;

    public int strength;
    public int armor;
    public int cardDraw;

    private void Start()
    {
        CollectCardData();
    }
   
    private void CollectCardData()
    {
        if (cardData == null)
        {
            Destroy(this.gameObject);
            return;
        }

        cardName = cardData.cardName;
        cardFlavor = cardData.cardFlavor;
        cardDesc = cardData.cardDesc;
        cardType = cardData.cardType;
        cardActions = cardData.cardAP;
        strength = cardData.cardStrength;
        armor = cardData.cardArmor;
        cardDraw = cardData.cardDrawAmt;

        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        cardNameText.text = cardName;
        cardDesc = cardData.cardDesc;
        cardDesc = ProcessDescription();
        cardDescText.text = cardDesc;
        cardFlavorText.text = cardFlavor;
        cardActionsText.text = cardActions.ToString().ToUpper();
        cardTypeText.text = cardType.ToString().ToUpper();
    }

    private string ProcessDescription()
    {
        string[] tempArr = cardDesc.Split(' ');
        string newCardDesc = "";
        cardDesc = "";
        switch (cardData.cardType)
        {
            // TODO ADD ALL CARD TYPES
            case CardTypes.DAMAGE:
                ParseDesc(strength);
            break;
            case CardTypes.BLOCK:
                ParseDesc(armor);
            break;
            case CardTypes.ABILITY:
                ParseDesc(cardDraw, armor);
            break;
        }
        return newCardDesc;
        string ParseDesc(int cardAttribute ,int cardAttribute2 = 0)
        {
            for (int i = 0; i < tempArr.Length; i++)
            {
                if (tempArr[i].ToUpper() == "X")
                {
                    tempArr[i] = cardAttribute.ToString();
                }
                if (tempArr[i].ToUpper() == "Y")
                {
                    tempArr[i] = cardAttribute2.ToString();
                }
                newCardDesc += tempArr[i];
            }
            return newCardDesc;
        }
    }

    public void UseCard()
    {
        var _gameManInst = GameManager.instance;
        var _cardManInst = CardManager.instance;
        if (_gameManInst.currentState == GameState.ENDMATCH)
        {
            //reset
            //rewards or punihsment
        }
        else// if (_gameManInst.currentState == GameState.COMBAT)
        {
            if (_cardManInst.CanUseCard(this))
            {
                _cardManInst.currentActions -= cardActions;
                //Card stuff here
                switch (cardType)
                {
                    //add all card types
                    case CardTypes.DAMAGE:
                        CombatManager.instance.DealDamage(strength,CombatManager.instance.currentEnemy,this);
                        break;
                    case CardTypes.BLOCK:
                        break;
                    case CardTypes.BUFF:
                        break;
                    case CardTypes.DEBUFF:
                        break;
                }

                UIManager.instance.UpdateDisplay();
            } 
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked card");
        UseCard();
    }
}
