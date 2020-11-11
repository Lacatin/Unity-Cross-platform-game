using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject arrowPrefab;
    private PlayerAnimations playerAnim;
    private Player player;


    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Start()
    {
        playerAnim = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (timeBtwShots <= 0)
        {

            if (Input.GetMouseButtonDown(1) && player.IsGrounded() == true)
            {
                playerAnim.RangedAttack();
                Invoke("Shoot", 0.72f);
                timeBtwShots = startTimeBtwShots;

            }

        }else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    void Shoot()
    {
        Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
    }


}
