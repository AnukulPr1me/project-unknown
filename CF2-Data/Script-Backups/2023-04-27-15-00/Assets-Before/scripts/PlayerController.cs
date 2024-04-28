using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    
    bool isMoving = false;
    

    public static PlayerController Instance;
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private SpriteRenderer theSR;
    private Animator anim;

    public float knockBackLength, knockBackForce;
    public float knockBackCounter;
    public Transform player;

    public Transform attackPoint;
    public int AttackDamage = 40;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    public bool IsFlip;


    //fireing
    public Transform firePoint;
    public GameObject bulletPrefab;



    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        player = GetComponent<Transform>();
        

    }


   


    // Update is called once per frame
    void Update()
    {
        if (Dialogue.isActive == true)
        {
            theRB.velocity = Vector3.zero;
            anim.enabled = false;
            return;
        }
        else
        {
            anim.enabled = true;
        }
       
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y); //movement

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround); //checking the ground for double jump

        if (theRB.velocity.x != 0)
        {
            isMoving = true;
        }
        else
            isMoving = false;

      
        

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }

        }
        //fliping the sprites
        if (theRB.velocity.x < 0)
        {

            // theSR.flipX = true;
            IsFlip = true;
            player.transform.rotation = new Quaternion(0f, 180, 0, 0);
            

        }
        else if (theRB.velocity.x > 0)
        {


            //theSR.flipX = false;
            IsFlip = false;
            player.transform.rotation = new Quaternion(0f, 0, 0, 0);
            
        }
       
        
        


        //  else

        //      knockBackCounter -= Time.deltaTime;
        //  if ()

        //  theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);


        //  else

        //  theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);




        //animation
        anim.SetFloat("isMoving", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }





        //fire

        fire();


    }
    public void knockBack() //player will move without the user control when it get hurt.
    {
        if (IsFlip == true)
        {

            theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            
            //knockBackCounter = 0;


        }
        else if (IsFlip == false)
        {
            theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
           
            //knockBackCounter = 0;
        }

        anim.SetTrigger("hurt");
    }

    void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Health>().takeDamage(AttackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
    public void fire()
    {
        if (Input.GetMouseButtonDown(1))
        {
            shoot();
            knockBack();
            mana_Orb.instance.cantFire();
            mana_Orb.instance.cantShoot();




        }

    }
    





}
