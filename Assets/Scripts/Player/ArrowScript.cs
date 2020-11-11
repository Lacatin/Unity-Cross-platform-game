using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public GameObject projectile;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", 0.5f);
    }

    void DestroyProjectile()
    {
        Destroy(projectile);
    }

}
