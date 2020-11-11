using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemySlime : Enemy, IDamageable
{


    public int Health { get; set; } = 45;
    public int remainingHP { get; set; }

    public HealthBar healthBar;

    public CoinSpawner coinSpawner;


    public override void Init()
    {
        base.Init();

        coinSpawner = GetComponentInChildren<CoinSpawner>();

        base.Hp = Health;
        remainingHP = Health;
        healthBar.SetMaxHealth(Health);

        base.dmg = 10;
        base.gems = 3;
        
    }

   
    public void Damage()
    {       
        remainingHP -= player.damage;
        healthBar.SetHealth(remainingHP);

        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("inCombat", true);

        if (remainingHP < 1)
        {
            Destroy(this.gameObject);
            coinSpawner.Spawn(gems);
            remainingHP = 0;
        }

        Debug.Log("HP:" + remainingHP);
    }

}




