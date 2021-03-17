using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour
{
    
    Vector3 direction;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Inimigos")) return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }

    private void Start() {
        
    }

    private void Update()
    {
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
        Thrust(direction.x, direction.y);
        if(Time.time == 1 ){
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() {
        gameObject.SetActive(false);
    }
}
