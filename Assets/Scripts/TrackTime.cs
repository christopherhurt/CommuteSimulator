using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTime : MonoBehaviour {

    private float timePassed;

	void Start () {
        timePassed = 0;
	}
    
	void Update () {
        timePassed += Time.deltaTime;
	}

    public int GetTimePassed()
    {
        return (int)timePassed;
    }

}
