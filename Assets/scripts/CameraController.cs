using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform farBackground; //middleGround; //add middleground later for better effect.

    public float minHeight, maxHeight;

    /*private float lastXPos;*/
    private Vector2 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        /*lastXPos = transform.position.x;*/
        lastPos = transform.position;
        Application.targetFrameRate = 1000;

    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position = new Vector3(target.position.x, target.position.y, target.position.z);*/

        /*float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);*/
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        /*float amountToMoveX = transform.position.x - lastXPos;*/

        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        //middleGround.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .005f;

        lastPos = transform.position;


    }
}

