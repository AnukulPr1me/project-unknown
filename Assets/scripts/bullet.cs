using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public int Damage = 40;


    public GameObject impactEffect;
    /*public int DamagePlayer;*/
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy_Health enemy =other.GetComponent<Enemy_Health>();
       


        if (other.CompareTag("Enemy"))
        {
            enemy.takeDamage(Damage);
            Destroy(gameObject, .2f);

        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);




    }
   


    /*    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "player")
            {
                playerHealthController.instance.dealDamage();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {

            Destroy(this.gameObject);
        }
    */

}
