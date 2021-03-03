using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tempo : MonoBehaviour
{
    Text textComp;
    GameManager gm;

    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        float minutes = Mathf.FloorToInt(gm.tempo / 60);  
        float seconds = Mathf.FloorToInt(gm.tempo % 60);

        textComp.text = string.Format("Tempo {0:00}:{1:00}", minutes, seconds);

    }
}
