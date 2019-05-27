using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDying : MonoBehaviour {

    public float fallTime;
    public float deathTime;

    private float initRot;
    private float fallDir;
    private float currRot;
    private float currDeath;
    private float fallStep;
    private float deathStep;

	void Start () {
        initRot = Random.value * 360;
        fallDir = Random.value < 0.5 ? 1 : -1;
        currRot = 0;
        currDeath = 0;
        fallStep = 1.0f / fallTime;
        deathStep = 1.0f / deathTime;

        transform.eulerAngles = new Vector3(-90, initRot, 0);
	}
	
	void Update () {
        currRot += fallStep * Time.deltaTime;
        currDeath += deathStep * Time.deltaTime;

        if (currDeath > 1.0f)
        {
            Destroy(this.gameObject);
        }

        if (currRot > 1.0f)
        {
            currRot = 1.0f;
        }
        
        transform.eulerAngles = new Vector3(-90 + currRot * fallDir * 90, initRot, 0);
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

}
