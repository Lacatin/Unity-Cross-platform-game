using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainHealing : MonoBehaviour
{

    public Player player;
    public void OnTriggerStay2D(Collider2D other)
    {

        player = other.GetComponent<Player>();

        if (player.remainingHP < player.Health)
        {
            player.remainingHP += 1;
            player.healthBar.SetHealth(player.remainingHP);
            player.healingEffect.enableEmission = true;
            StartCoroutine(WaitForHeal());
            Debug.Log(player.remainingHP);
        }
        else
            player.healingEffect.enableEmission = false;
    }

    IEnumerator WaitForHeal()
    {
        yield return new WaitForSeconds(1f);
    }

}
