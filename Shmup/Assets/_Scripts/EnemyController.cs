using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    public GameObject tiro;
    GameManager gm;

    int vida = 3;

    private void Start() {
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        Instantiate(tiro, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        vida--;
        if(vida <= 0) Die();
    }

    public void Die()
    {
        gm.pontos ++;
        Destroy(transform.parent.gameObject);
    }
    
}
