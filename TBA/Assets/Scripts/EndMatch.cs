using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMatch : MonoBehaviour
{
    public Button healthUp;
    public Button actionsUp;
    public Button handSizeUp;

    private void OnDisable()
    {
        GameManager.instance.ChangeState(GameState.COMBAT);
        EnemyManager.instance.SpawnEnemy();
        CardManager.instance.isStartingDraw = true;
        CardManager.instance.InitialDraw();
        
    }
}
