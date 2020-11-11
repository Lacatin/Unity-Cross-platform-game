
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class DropedCoin : MonoBehaviour
{
    private Player player;

    private float upForce = 0.5f;
    private float sideForce = 1f;
    public Rigidbody2D rb2d;

    private float xForce;
    private float yForce;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        xForce = Random.Range(-sideForce, sideForce);
        yForce = Random.Range(upForce /2f, upForce);

        rb2d.AddForce(transform.up * yForce, ForceMode2D.Impulse);
        rb2d.AddForce(transform.right * xForce, ForceMode2D.Impulse);

        Invoke("Stopping", 0.2f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.gemsCollected++;
            Destroy(this.gameObject);
        }
    }

    void Stopping()
    {
        rb2d.velocity = Vector3.zero;
    }

}
