using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    #region Variables
    public CurrentTurn currentTurn;
    public int stableTurnsLeft = 10;
    public GameObject newCardPrefab;

    public Transform drawContainer; //Cards Draw Area
    public Transform discardContainer; //Cards Discard Area
    public Transform handConatiner; //Current Hand Area
    [Header("Current Player Deck")]
    //cards in deck
    public List<CardData> currentDeck = new List<CardData>();
    [Header("All Cards Availabale")]
    //all cards in game(Place any new cards in this list)
    public List<CardData> allCardsPossible = new List<CardData>();

    //default hand size
    public int startingHandSize = 2;
    //max hand size
    public int maxHandSize = 4;

    //action points
    public int actionsAtStart = 3;
    public int currentActions = 0;

    public int ActionsAtStart { get { return actionsAtStart; } set { actionsAtStart += value; } }
    public int MaxHandSize { get { return maxHandSize; } set { maxHandSize += value; } }
    public int StartHandSize { get { return startingHandSize; } set { startingHandSize += value; } }


    

    //Draw
    public bool isStartingDraw = false;
    //UI
    public TextMeshProUGUI drawText;
    public TextMeshProUGUI discardText;

    public Button endTurnButton;

    #endregion

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
       
        isStartingDraw = true;
        LoadDeck();
    }

    private void LoadDeck()
    {
        for(int i = 0; i < currentDeck.Count; i++)
        {
            GameObject newCard = Instantiate(newCardPrefab, drawContainer);
            newCard.GetComponent<Card>().cardData = currentDeck[i];
            newCard.name = newCard.GetComponent<Card>().cardData.cardName;

            newCard.transform.localPosition = new Vector3(newCard.transform.localPosition.x, newCard.transform.localPosition.y, newCard.transform.localPosition.z+i);
        }
        UpdateDisplay();
        EnemyManager.instance.SpawnEnemy();
        InitialDraw();
    }
    public void UpdateDisplay()
    {
       // drawText.text = drawContainer.childCount.ToString();
        //discardText.text = discardContainer.childCount.ToString();

        for (int i = 0; i < handConatiner.childCount; i++)
        {
           //check if we can use cards
           Card card = handConatiner.transform.GetChild(i).GetComponent<Card>();
           if (CanUseCard(card))
           {
               //change color of action cost
               card.cardActionsText.color = Color.yellow;
           }
           else
           {
               card.cardActionsText.color = Color.grey;
           }
        }
    }
    public void InitialDraw() 
    {
        CombatManager.instance.currentEnemy.OnTurnEnd();
       
        currentTurn = CurrentTurn.PLAYER;
        endTurnButton.interactable = true;
        currentActions = actionsAtStart;

        if (handConatiner.childCount < startingHandSize)
        {
            DrawCard();
        }
        else 
        {
            isStartingDraw = false;
        }
        UIManager.instance.UpdateDisplay();
       UpdateDisplay();
    }

    private void DrawCard()
    {
        if (drawContainer.childCount > 0)
        {
            int rand = Random.Range(0, drawContainer.childCount);
            drawContainer.GetChild(rand).transform.SetParent(handConatiner,false);
        }
        else if (drawContainer.childCount<=0)
        {
            ShuffleDeck();
        }

        if(isStartingDraw)
        {
            InitialDraw();
        }

    }

    public IEnumerator DrawCards(Card card)
    {
        int drawAmt = card.cardDraw;

        for(int i = 0; i < drawAmt; i++)
        {
            DrawCard();
            Debug.Log("Card Drawn");
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForEndOfFrame();
        DiscardCard(card);
    }

    public void DiscardCard(Card card)
    {
        for (int i = 0; i < handConatiner.childCount; i++)
        {
            if(handConatiner.GetChild(i).GetComponent<Card>()==card)
            {
                Transform _transform = handConatiner.GetChild(i);

                _transform.SetParent(discardContainer);

                ResetCardTransform(_transform);
                _transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y, _transform.localPosition.z + i);
                UpdateDisplay();

                return;
            }
        }
    }

    public void DiscardAllCards()
    {
        for (int i = handConatiner.childCount-1;i>=0; i--)
        {
            DiscardCard(handConatiner.GetChild(i).GetComponent<Card>());
        }
    }
        
    public void ShuffleDeck()
    {
        for(int i = discardContainer.childCount - 1 ; i >= 0 ; i--)
        {
            Transform tempCard = discardContainer.GetChild(i);

            tempCard.transform.SetParent(drawContainer);
            ResetCardTransform(tempCard);
        }
        UpdateDisplay();
    }

    public void ResetCardTransform(Transform card)
    {
        card.localPosition = Vector3.zero;
    }

    public bool CanUseCard(Card card)
    {

        return currentActions > 0 && card.cardActions <= currentActions ;
        
    }
    public void StartNewTurn() 
    {
        CombatManager.instance.currentArmor = 0;
        isStartingDraw = true;
        InitialDraw();
        endTurnButton.gameObject.SetActive(true);
    }

    public void EndTurn()
    {
        DiscardAllCards();
        endTurnButton.gameObject.SetActive(false);
        currentTurn = CurrentTurn.ENEMY;
        CombatManager.instance.currentEnemy.armor = 0;

        StartCoroutine(EnemyManager.instance.TakeTurn(CombatManager.instance.currentEnemy));
        UpdateDisplay();

    }
    public IEnumerator DrawRewardCards(int rewardAmt)
    {


        for (int i = 0; i < rewardAmt; i++)
        {
            DrawRewardCard();
            Debug.Log("Reward Card Drawn");
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForEndOfFrame();

    }

    private void DrawRewardCard()
    {
        if (drawContainer.childCount > 0)
        {
            int rand = Random.Range(0, drawContainer.childCount);
            drawContainer.GetChild(rand).transform.SetParent(handConatiner, false);
        }


 

    }
}
