using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBriefcase : MonoBehaviour {

    public Transform player;
    public float height;
    public float offset;
    public float swipeSpeed;

    private bool swiping;
    private float startAngle;
    private float endAngle;

    void Update () {
        DoSwipe();
	}

    void DoSwipe()
    {
        if (swiping)
        {
            startAngle += swipeSpeed * Time.deltaTime;

            Vector3 pos = new Vector3(player.position.x, height, player.position.z);
            
            Vector3 dir = new Vector3(Mathf.Sin(Mathf.Deg2Rad * startAngle), 0, Mathf.Cos(Mathf.Deg2Rad * startAngle));
            pos += dir * offset;

            transform.position = pos;
            transform.eulerAngles = new Vector3(0, startAngle + 180, 90);

            if (startAngle >= endAngle)
            {
                swiping = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void Swipe(float angleFromForward, float swingAngle)
    {
        startAngle = angleFromForward - swingAngle / 2;
        endAngle = angleFromForward + swingAngle / 2;

        swiping = true;
        DoSwipe();

        gameObject.SetActive(true);
    }

}
