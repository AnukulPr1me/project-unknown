using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;
    

    private Animator anim;

    public

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateCheckpoints();
            anim.SetTrigger("spawn");
            
            CheckpointController.instance.setSpawnPoint(transform.position);
            
            


        }
    }

    public void ResetCheckPoint()
    {

        anim.ResetTrigger("spawn");

        
    }
}
