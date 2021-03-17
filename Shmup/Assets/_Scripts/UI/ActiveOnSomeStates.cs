using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActiveOnSomeStates : MonoBehaviour
{
    public GameManager.GameState[] activeStates;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += UpdateVisibility;
        GameManager.pauseChangeStateDelegate += UpdateVisibility;
        UpdateVisibility();
    }

    void UpdateVisibility()
    {
        if(activeStates.Contains(gm.gameState))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
