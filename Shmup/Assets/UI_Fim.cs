using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fim : MonoBehaviour
{
    public Text message;

    GameManager gm;
    void OnEnable()
    {
        gm = GameManager.GetInstance();

        if(gm.vidas <= 0 )
        {
            message.text = $"Você fez {gm.pontos} pontos !!!";
        }
    }

    public void Menu()
    {
        gm.changeState(GameManager.GameState.MENU);
    }

    public void Voltar()
    {
        gm.changeState(GameManager.GameState.GAME);
    }
}

