using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Level_Manage.Instance.RespawnPlayer();
            PlayerController.Instance.moveSpeed= 0;
            PlayerController.Instance.jumpForce= 0;
            
        }
        
    }
}
