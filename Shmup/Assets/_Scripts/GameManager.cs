using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    public enum GameState { MENU, GAME, PAUSE, ENDGAME}

    public GameState gameState {get; private set; }

    public int vidas;
    public int pontos;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;
    public static ChangeStateDelegate pauseChangeStateDelegate;

    private static GameManager _instance;

    private GameManager()
    {

        vidas = 10;
        pontos = 0;
        gameState = GameState.MENU;
    }

    public static GameManager GetInstance()
    {
        if (_instance == null) {
            _instance = new GameManager();
        }
        return _instance;
    }

    public void changeState(GameState nextState)
    {
        if (gameState != GameState.PAUSE && nextState == GameState.GAME) {
            Reset();
            gameState = nextState;
            changeStateDelegate();
        }
        else if (gameState == GameState.PAUSE && nextState == GameState.GAME) {
            gameState = nextState;
            pauseChangeStateDelegate();
        } else {
            gameState = nextState;
            changeStateDelegate();
        }
           
        
    }

    private void Reset() {
        vidas = 10;
        pontos = 0;
        // tempo = 120.0f;

        // GameObject[] enemies = GameObject.FindGameObjectsWithTag("tiro" );
        // foreach(GameObject enemy in enemies)
        // {
        //     Destroy(enemy);
        //     // Do something to each enemy (link up a reference, check for damage, etc.)
        // }
        // Destroy(GameObject.FindGameObjectsWithTag("tiro")); 
    }
}
