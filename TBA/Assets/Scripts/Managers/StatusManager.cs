using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static  StatusManager instance;
    public StatusData equilibrium;
    public StatusData unstable;
    public StatusData disorder;

    public Dictionary<StatusType, StatusData> statusDict = new Dictionary<StatusType, StatusData>();

    public GameObject playerStatusPrefab;

    public Transform playerStatusContainer;
    public Transform enemyStatusContainer;
    public GameObject enemyStatusPrefab;

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
        statusDict.Clear();
        statusDict.Add(StatusType.DISORDER,disorder);
        statusDict.Add(StatusType.EQUILIBRIUM,equilibrium);
        statusDict.Add(StatusType.UNSTABLE,unstable);
    }

    public StatusData GetStatus(StatusType status)
    {
        return statusDict[status];
    }

    public void CreateStatus(StatusType status, bool isEnemy)
    {
        if (isEnemy)
        {
            GameObject gameObject = Instantiate(enemyStatusPrefab, enemyStatusContainer);
        }
        else
        {
            GameObject gameObject = Instantiate(playerStatusPrefab, playerStatusContainer);
        }

    }

    public void RemoveStatus(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void UpdateStatusUI()
    {
        
    }

    public void AddStatus(CurrentTurn effected, StatusType status)
    {
        switch (effected)
        {
            case CurrentTurn.PLAYER:
                break;
            case CurrentTurn.ENEMY:
                break;
        }
    }
}
