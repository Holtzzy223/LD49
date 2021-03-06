using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    PAUSE,
    MAP,
    COMBAT,
    ENDMATCH,
    LOSE,
    WIN
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState currentState;
    public AudioSource audioSource;
    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        audioSource.Play();
    }
    public void ChangeState(GameState newState)
    {
        if (instance.currentState == newState)
        {
            return;
        }
        instance.currentState = newState;

        switch (newState)
        {
            // add in all game states
            case GameState.PAUSE:
                //Logic goes here
                
                break;
            case GameState.MAP:
                //Logic goes here
                break;
            case GameState.COMBAT:
                //Logic goes here
                break;
            case GameState.ENDMATCH:
                //Logic Goes here
                //pop end match UI
                UIManager.instance.rewardContainer.SetActive(true);
                break;

        }
    }


}
