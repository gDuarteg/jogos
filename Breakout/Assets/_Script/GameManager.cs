using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }

    public int vidas;
    public int pontos;
    public float tempo;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;
    // public static ChangeStateDelegate changeStateDelegate2;

    private static GameManager _instance;

    private GameManager()
    {
        vidas = 3;
        pontos = 0;
        tempo = 120.0f;
        gameState = GameState.MENU;
    }

    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    
    public void changeState(GameState nextState)
    {
        
        if(nextState == GameState.GAME) Reset();

        gameState = nextState;
        
        changeStateDelegate();
    }

    private void Reset() {
        vidas = 3;
        pontos = 0;
        tempo = 120.0f;   
    }

}