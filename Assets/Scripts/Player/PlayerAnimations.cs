using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Move(float horizontalInput)
    {

        anim.SetFloat("Move", Mathf.Abs(horizontalInput));

    }

    public void Jump (bool jumping)
    {

        anim.SetBool("Jumping", jumping);

    }

    public void MeeleAttack()
    {
        anim.SetTrigger("Meele Attack");
    }

    public void RangedAttack()
    {
        anim.SetTrigger("Ranged Attack");
    }
}
