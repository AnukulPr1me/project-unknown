using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    [Header ("Patrol Point")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private bool movingLeft;

    [Header ("Idel Behaviour")]
    [SerializeField] private float idelDuration;
     private float idelTimer;


    [Header("Enemy Animation")]
    [SerializeField]private Animator anim;


    public int Health = 100;


    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void directionChange()
    {
        anim.SetBool("moving", false);
        idelTimer += Time.deltaTime;
        if (idelTimer > idelDuration)
        {
            movingLeft = !movingLeft;
        }   
    }



    private void MoveInDirection(int _direction)
    {
        idelTimer = 0;

        anim.SetBool("moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) *
            _direction, initScale.y,initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * 
            _direction * speed, enemy.position.y, enemy.position.z);

    }
  

    // Update is called once per frame
    void Update()
    {
        if(movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                //change_Direction
                directionChange();
            }
            
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //change_Direction
                directionChange();
            }

        }

    }
}
