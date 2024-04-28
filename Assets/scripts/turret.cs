using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public float Range;
    public Transform Target;

    bool detected = false;

    Vector2 Direction;

    public GameObject AlarmLight;

    public GameObject gun;

    public GameObject bullet;

    public float fireRate;

    private float nextTimeToFire = 0;

    public Transform shootPoint;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetpos = Target.position;
        Direction = targetpos - (Vector2)(transform.position);
        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayinfo)
        {
            if (rayinfo.collider.gameObject.tag == "Player")
            {
                if (detected == false)
                {
                    detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green; 

                }
                else
                {
                    if (detected == false)
                    {
                        detected = true;
                        AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;

                    }
                }
            }
        }
        if (detected)
        {
            gun.transform.up = Direction;

            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                shoot();
            }
        }
    }

    public void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, shootPoint.position, Quaternion.identity);

        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);
    }
}
