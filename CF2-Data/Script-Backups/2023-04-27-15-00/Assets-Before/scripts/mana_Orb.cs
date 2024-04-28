using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mana_Orb : MonoBehaviour
{
    public static mana_Orb instance;


    public int currentMana, maxMana;
    private SpriteRenderer theSR;
    public manaBar Manabar;
    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        theSR = GetComponent<SpriteRenderer>();
        

    }

    public void cantFire()
    {
        if(Input.GetMouseButtonDown(1))
        {
            currentMana = currentMana -= 30;
            Manabar.SetMana(currentMana);
            Debug.Log("hi");
            
        }
    }
    public void fillMana()
    {
        currentMana = maxMana;

        if(currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        manaBar.instance.setMaxMana(currentMana);
    }

    
    public void cantShoot()
    {
        if(currentMana <= 0)
        {
            PlayerController.Instance.bulletPrefab.SetActive(false);
            PlayerController.Instance.knockBackForce = 0f;

        }
        else
        {
            PlayerController.Instance.bulletPrefab.SetActive(true);
            PlayerController.Instance.knockBackForce = 5f;
        }
    }
/*    public void noKnockback()
    {
        if(currentMana <= 0)
        {
            PlayerController.Instance.knockBackForce = 0f;
            PlayerController.Instance.GetComponent<Animator>().enabled = false;
            

        }
    }*/

  

    
}
