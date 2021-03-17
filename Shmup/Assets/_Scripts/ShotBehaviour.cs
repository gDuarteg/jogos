using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{
    GameManager gm;

    private void Start() {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += ResetBullet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }

    private void ResetBullet() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("tiro" );
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    private void Update()
    {
        if(gameObject.transform.position.x >= 50){
            Destroy(gameObject);
        }
        Thrust(5, 0);
        
    }
}
