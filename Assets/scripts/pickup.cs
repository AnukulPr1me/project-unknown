using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public static pickup instance;
    public bool isOrb, isHeal;
    private bool isCollected;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.instance.slider.value = playerHealthController.instance.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            if (isOrb)
            {
                
                /*Level_Manage.Instance.orbsCollected++;*/
                if(mana_Orb.instance.currentMana != mana_Orb.instance.maxMana)
                {
                    mana_Orb.instance.fillMana();
                    Destroy(gameObject);
                }

                isCollected = true;
                Destroy(gameObject);
                

                /*UIController.instance.UpdateOrbsCount();*/
            }
            else
            {
                
            }
            if(isHeal)
            {
                if(playerHealthController.instance.currentHealth != playerHealthController.instance.maxHealth)
                {
                    
                    playerHealthController.instance.healPlayer();
                    Destroy(gameObject);
                }
                
            }
        }
        
    }
}
