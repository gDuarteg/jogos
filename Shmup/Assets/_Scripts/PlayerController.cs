using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    
    GameManager gm;

    public AudioClip shootSFX;

    public GameObject bullet;
    public Transform arma;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    private void Start() {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;

        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        gm.vidas--;
        if (gm.vidas <= 0) Die();
    }

    public void Die()
    {
        // gameObject.active = false;
        // Destroy(gameObject);
        if (gm.gameState == GameManager.GameState.GAME)
        {
            gm.changeState(GameManager.GameState.ENDGAME);
        }
    }

    void FixedUpdate()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;   
        
        if(Input.GetKeyDown(KeyCode.P) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.changeState(GameManager.GameState.PAUSE);
        }
        
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
    
        if(yInput != 0 || xInput !=0) {
            animator.SetFloat("Velocity", 1.0f);
        } else {
            animator.SetFloat("Velocity", 0.0f);
        }
        if(Input.GetAxisRaw("Jump") != 0)
        {
            Shoot();
        }
        
    }    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Inimigos")) {
            // Destroy(other.gameObject);
            TakeDamage();
            
        }
    }
    
}
