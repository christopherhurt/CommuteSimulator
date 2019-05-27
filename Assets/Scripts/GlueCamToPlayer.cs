using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueCamToPlayer : MonoBehaviour {

    public Transform player;
    public float depthOffset;
    public float heightOffset;
    public float tilt;

    void Start()
    {
        transform.eulerAngles = new Vector3(tilt, 0, 0);
    }

    void LateUpdate () {
        Vector3 playerPos = player.position;
        Vector3 camPos = playerPos + (new Vector3(0, heightOffset, depthOffset));
        transform.position = camPos;
	}

}
