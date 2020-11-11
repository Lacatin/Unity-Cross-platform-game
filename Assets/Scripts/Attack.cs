using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDmg = true;
    [SerializeField]


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit" + collision.name);
        IDamageable hit = collision.GetComponent<IDamageable>();

        if(hit != null)
        {
            if (canDmg == true)
            {

                hit.Damage();
                canDmg = false;
                StartCoroutine(ResetDamage());

            }
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        canDmg = true;
    }

}
