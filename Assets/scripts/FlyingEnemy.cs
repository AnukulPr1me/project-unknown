using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;

    private GameObject player;

    public bool chase = false;
    public Transform StartingPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (player == null)
            return;

        if (chase == true)
        {
            Chase();
        }

        else
        {
            ReturnStartingPoint();
        }
        Flip();

    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed *Time.deltaTime);
    }

    private void ReturnStartingPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, StartingPoint.position, speed *Time.deltaTime);
    }
    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

}
