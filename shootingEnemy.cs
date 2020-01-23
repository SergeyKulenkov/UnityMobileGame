using UnityEngine;
using System.Collections;

public class shootingEnemy : enemy //inheritance from enemy class
{
    public GameObject bomb;
    public Transform shootingPosition;

    private bool canShoot = false;
    
    private  float shootingTimer = 0f;
    private float defaultShootingTimer = 1.5f;

    protected override void Start ()
    {   //using enemy Start class and initializing some unique variables
        base.Start();
        health = 20;
        scorePoints = 15;
        distance += 3;
    }

    protected override void Update()
    {   //using enemy Update method
        base.Update();
        if (canShoot)
        {   
            if (shootingTimer > 0)
            {
                shootingTimer -= Time.deltaTime;
            }
            else
            {   //shooting if cooldown <= 0
                Instantiate(bomb, shootingPosition.position, transform.rotation);
                shootingTimer = defaultShootingTimer;
            }
        }
    }
        
    protected override void Attack()
    {
        base.Attack();
        canShoot = true;
    }

    protected override void DontAttack()
    {
        base.DontAttack();
        canShoot = false;
    }
}
