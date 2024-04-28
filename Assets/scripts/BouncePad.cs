using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public AudioSource jumppad;
    private Animator Anim;

    public float bounceForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            jumppad.enabled = true;
            PlayerController.Instance.theRB.velocity = new Vector2(PlayerController.Instance.theRB.velocity.x, bounceForce);
            Anim.SetTrigger("Bounce");
        }
        else
        {
            jumppad.enabled = false;
        }
    }
}
