using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR;

public class Player : MonoBehaviour, IDamageable

{
    private Rigidbody2D rb;
    private PlayerAnimations playerAnim;
    private SpriteRenderer playerSprite;

    [SerializeField]
    private Transform firepoint;



    //JUMPING
    [SerializeField]
    private float jumpingForce = 4.5f;
    [SerializeField]
    private float movementSpeed = 3;
    private float fallMultiplier = 2f;
    private bool isGrounded = false;

    //COMBAT
    public int damage = 20;
    private Enemy enemy;

    //COLLECTABLES
    public int gemsCollected = 0;

    //HEALTH
    public int Health { get; set; }
    public int remainingHP { get; set; }
    public HealthBar healthBar;

    //LEVELING
    public int level = 1;
    public float experience = 100;
    public float experienceNeeded = 100;
    public XpBar XpBar;

    //EFFECTS
    [SerializeField]
    public ParticleSystem healingEffect;

    [SerializeField]
    public ParticleSystem runningEffect;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimations>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        healingEffect.enableEmission = false;
        runningEffect.enableEmission = false;

        Health = 100;
        remainingHP = Health;
        healthBar.SetMaxHealth(Health);

        XpBar.SetXp(experience);

    }

    void Update()
    {
        Movement();
        MeeleAttack();


    }

    void Movement()
    {
        //MOVING
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded();
        Flip(horizontalInput);
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        playerAnim.Move(horizontalInput);
        runningEffect.enableEmission = true;

        if (horizontalInput == 0 || IsGrounded() == false)
            runningEffect.enableEmission = false;


        //JUMPING
        SmootherJump();

    }

    public bool IsGrounded()
    {
        RaycastHit2D isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, 1 << 8);

        if (isGrounded.collider != null)
        {
            playerAnim.Jump(false);
            return true;
        }
        else
        {
            playerAnim.Jump(true);
            return false;
        }


    }

    private void SmootherJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);

        }
    }

    private void Flip(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            playerSprite.flipX = false;
            runningEffect.transform.localPosition = new Vector2(-0.25f, -0.6f);
            runningEffect.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
            firepoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
            playerSprite.flipX = true;
            runningEffect.transform.localPosition = new Vector2(0.25f, -0.6f);
            runningEffect.transform.rotation = Quaternion.Euler(0f, 0f, 220f);
            firepoint.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
    }

    void MeeleAttack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
            playerAnim.MeeleAttack();
        }
    }

    public void Damage()
    {
        enemy = Attack.FindObjectOfType<Enemy>().GetComponent<Enemy>();

        remainingHP -= enemy.dmg;
        Debug.Log("The player has " + remainingHP + " left.");
        healthBar.SetHealth(remainingHP);

        if (remainingHP < 1)
        {
            Destroy(this.gameObject);
            remainingHP = 0;
        }
    }

    public void LevelUp(int amount)
    {
        Health = Health + (int)0.15 * Health;
        remainingHP = Health;
        healthBar.SetMaxHealth(Health);

        experienceNeeded = experienceNeeded + (int)0.5 * experienceNeeded;
        experience -= experienceNeeded;

        damage = damage + (int) 0.25 * damage;
    }

}