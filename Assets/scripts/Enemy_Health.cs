using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
    
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            anim.SetTrigger("die");
            this.enabled= false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Enemy_melee>().enabled = false;
            Debug.Log("enemey died");
        }
    }    
}
