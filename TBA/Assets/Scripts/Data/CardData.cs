using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Card_", menuName = "New Card")]
public class CardData : ScriptableObject
{
    //Info
    public string cardName;   //card's name
    public CardTypes cardType;
    public int cardPrice;     //card's price at shop
    public int cardAP;        //cards's Action Cost
    public Sprite cardArtImage;  //Artwork for Card Image
  
    [Multiline] 
    public string cardFlavor; //Flavor Text
    [Multiline]
    public string cardDesc;   //Card Description
    //Stats
    public int cardStrength;  //Attack power
    public int cardArmor;     //Defense Power
    //Abilties
    public int cardDrawAmt;   //Cards to draw, if card has a draw ability
    public int cardBlock;     // Damge to block if card has block ability

    //Effects
    //functions

    public Sprite GetBackerImage()
    {
        Sprite backerImage = null;
        switch (cardType)
        {
            case CardTypes.DAMAGE:
                backerImage = Resources.Load<Sprite>("Art/CardBackers/cardBackerDamage");
                break;
            case CardTypes.ABILITY:
                backerImage = Resources.Load<Sprite>("Art/CardBackers/cardBackerAbility");
                break;
            case CardTypes.BUFF:
                backerImage = Resources.Load<Sprite>("Art/CardBackers/cardBackerBuff");
                break;
            case CardTypes.DEBUFF:
                backerImage = Resources.Load<Sprite>("Art/CardBackers/cardBackerDebuff");
                break;
        }
        return backerImage;
    }
}
