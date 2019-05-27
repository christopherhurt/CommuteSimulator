using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private static Vector3 FORWARD = new Vector3(0, 0, 1);
    private static Vector3 BACKWARD = new Vector3(0, 0, -1);
    private static Vector3 LEFT = new Vector3(-1, 0, 0);
    private static Vector3 RIGHT = new Vector3(1, 0, 0);

    public float speed;
    public float maxForward;
    public float maxBackward;
    public float maxLeft;
    public float maxRight;

	void Update () {
        Vector3 direction = new Vector3(0, 0, 0);
        bool moving = false;
        bool leftDown = false;

        if(Input.GetKey(KeyCode.W))
        {
            direction += FORWARD;
            moving = true;
        }
        if(Input.GetKey(KeyCode.S))
        {
            direction += BACKWARD;
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += LEFT;
            moving = true;
            leftDown = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += RIGHT;
            moving = true;
        }

        Vector3 moveAmt = direction.normalized * speed * Time.deltaTime;
        transform.position += moveAmt;

        Vector3 pos = transform.position;
        if(pos.z > maxForward)
        {
            pos.z = maxForward;
        }
        else if(pos.z < -maxBackward)
        {
            pos.z = -maxBackward;
        }
        if(pos.x < -maxLeft)
        {
            pos.x = -maxLeft;
        }
        else if(pos.x > maxRight)
        {
            pos.x = maxRight;
        }
        transform.position = pos;

        if (moving)
        {
            float angleBetween = Mathf.Rad2Deg * Mathf.Acos(direction.normalized.z);
            transform.eulerAngles = new Vector3(0, 180 + angleBetween * (leftDown ? -1 : 1), 0);
        }
	}

}
