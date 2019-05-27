using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour {

    public float moveSpeed;
    public float turnRange;
    public float maxDepth;

    private Vector3 initialDirection;
    private bool turned;
    private Vector3 turnDirection;
    private float turnLoc;

    void Start()
    {
        turned = false;
        turnDirection = new Vector3(0, 0, 0);
        turnLoc = (Random.value * 2 - 1) * (turnRange / 2);
    }

    void Update () {
        if (turned)
        {
            transform.position += turnDirection * Time.deltaTime;

            if(transform.position.z > maxDepth)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxDepth);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y == 0 ? 180 : 0, 0);
                turnDirection *= -1;
            }
            else if(transform.position.z < -maxDepth)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -maxDepth);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y == 0 ? 180 : 0, 0);
                turnDirection *= -1;
            }
        }
        else
        {
            transform.position += initialDirection * Time.deltaTime;

            if((initialDirection.x > 0 && transform.position.x >= turnLoc) || (initialDirection.x < 0 && transform.position.x <= turnLoc))
            {
                float dir = Random.value < 0.5f ? 1 : -1;
                turnDirection = new Vector3(0, 0, moveSpeed * dir);
                transform.eulerAngles = new Vector3(0, dir > 0 ? 180 : 0);
                turned = true;
            }
        }
	}

    public void SetInitialDirection(Vector3 dir)
    {
        initialDirection = dir.normalized * moveSpeed;
    }

}
