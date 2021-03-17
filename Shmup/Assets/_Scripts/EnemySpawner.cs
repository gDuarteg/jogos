using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += SpawnShips;
    }

    void SpawnShips(){
        if (gm.gameState == GameManager.GameState.GAME)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            for (int i=0; i<3; i++) {
                Vector3 position = new Vector3(1+i,1+i);
                Instantiate(Enemy, position, Quaternion.identity, transform);
            }
        }
    }

    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME){
            SpawnShips();
        }
    }
}
