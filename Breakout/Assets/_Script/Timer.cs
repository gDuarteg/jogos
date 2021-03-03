using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.tempo <= 1 && gm.gameState == GameManager.GameState.GAME){
            gm.vidas = 0;
            gm.changeState(GameManager.GameState.ENDGAME);
        }
        if(gm.tempo >= 1 && gm.gameState == GameManager.GameState.GAME){
            gm.tempo -= 1 * Time.deltaTime;
        }
    }
}
