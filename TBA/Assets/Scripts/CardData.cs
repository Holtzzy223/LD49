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

}
