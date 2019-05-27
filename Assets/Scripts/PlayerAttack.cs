using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject deadPerson;
    public ControlBriefcase briefcase;
    public float attackRange;
    public float swingAngle;
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseLoc = Input.mousePosition;
            Vector2 mousePos = new Vector2(mouseLoc.x / Screen.width, mouseLoc.y / Screen.height);
            Vector2 attackDir = (mousePos * 2 - new Vector2(1, 1)).normalized;

            float angleFromForward = Mathf.Rad2Deg * Mathf.Acos(attackDir.y) * (attackDir.x > 0 ? 1 : -1);
            briefcase.Swipe(angleFromForward, swingAngle);

            GameObject[] people = GameObject.FindGameObjectsWithTag("Person");
            foreach(GameObject person in people)
            {
                Vector3 toPerson3 = (person.GetComponent<Transform>().position - transform.position);
                Vector2 toPerson = new Vector2(toPerson3.x, toPerson3.z);
                float distance = toPerson.magnitude;
                if(distance <= attackRange)
                {
                    Vector2 toPersonNorm = toPerson.normalized;
                    float angleBetween = Mathf.Rad2Deg * Mathf.Acos(attackDir.x * toPersonNorm.x + attackDir.y * toPersonNorm.y);
                    if(angleBetween < swingAngle / 2)
                    {
                        Kill(person);
                    }
                }
            }
        }
	}

    private void Kill(GameObject person)
    {
        Destroy(person);
        GameObject dead = Instantiate(deadPerson);
        PersonDying deadScript = dead.GetComponent<PersonDying>();
        deadScript.SetPosition(person.transform.position);
        dead.SetActive(true);
    }

}
