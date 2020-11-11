using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
   
    public int dmg;

    [SerializeField]
    protected int gems;
    [SerializeField]
    protected int Hp;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected Transform pointA, pointB;


    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Player player;


    protected bool isHit = false;
    private float distance;
    private Vector3 direction;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("inCombat") == false)
        {
            return;
        }

        Movement();

    }
        
    public virtual void Movement()
    {

        if (currentTarget == pointB.position)
        {
            sprite.flipX = true;
        }
        else if (currentTarget == pointA.position)
        {
            sprite.flipX = false;
        }


        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if(distance > 4f)
        {
            isHit = false;
            anim.SetBool("inCombat", false);
        }

        direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("inCombat") == true)
        {
            sprite.flipX = true;
        }
        else if (direction.x < 0 && anim.GetBool("inCombat") == true)
        {
            sprite.flipX = false;
        }
    }

}
