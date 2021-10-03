using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMatch : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.ChangeState(GameState.ENDMATCH);
        CardManager.instance.DiscardAllCards();
        //Display Cards/Enchantment choices
    }
}
