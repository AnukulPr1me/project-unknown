using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    public static playerHealthController instance;

    public int currentHealth, maxHealth;
    
    public HealthBar healthBar;

    public Animator anim;

    public float invincibleLength;
    private float invincibleCounter;
   

    private SpriteRenderer theSR;

    public float delay;

    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR= GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
       

        if (invincibleCounter >0) // will not hurt player if player alrady damaged 1 sec ago.
        {
            invincibleCounter -= Time.deltaTime;
            
            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
        
    }
    
    public void dealDamage()//will damage player
    {

        if (invincibleCounter <= 0)
        {
            currentHealth = currentHealth -= 30;
            healthBar.setHealth(currentHealth);


            if (currentHealth <= 0)
            {
                currentHealth = 0;
               

                dead();

                
                /*gameObject.SetActive(false);*/
                Level_Manage.Instance.RespawnPlayer();
                
                
                

            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .7f);

                PlayerController.Instance.knockBack();

            }
           
        }
       
         
       
    }

   
    
    public void healPlayer()
    {
        currentHealth = maxHealth;
        if(currentHealth >maxHealth)
        {
            currentHealth = maxHealth;
        }

        HealthBar.instance.setHealth(currentHealth);

    }
    public void dead()
    {
       
        if(currentHealth <= 0)
        {
            
            anim.SetTrigger("player_Death");

            PlayerController.Instance.moveSpeed = 0;
            PlayerController.Instance.jumpForce= 0;

        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }


}   
