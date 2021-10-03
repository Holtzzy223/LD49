using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public StatusManager instance;
    public StatusData equilibrium;
    public StatusData unstable;
    public StatusData disorder;

    public Dictionary<Status, StatusData> statusDict = new Dictionary<Status, StatusData>();

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
        statusDict.Add(Status.DISORDER,disorder);
        statusDict.Add(Status.EQUILIBRIUM,equilibrium);
        statusDict.Add(Status.UNSTABLE,unstable);
    }

    public StatusData GetStatus(Status status)
    {
        return statusDict[status];
    }

    public void CreateStatus(Status status, bool isEnemy)
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
}
