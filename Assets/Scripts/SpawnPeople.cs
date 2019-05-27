using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour {

    public GameObject person;
    public float spawnRate;
    public float horizontalDistance;
    public float entranceSpacing;
    public int numberOfEntrances;
    public float personYPosition;

    void Update () {
        float spawnChance = spawnRate * Time.deltaTime;
        
        if(Random.value < spawnChance)
        {
            GameObject unit = Instantiate(person);
            Transform unitTransform = unit.GetComponent<Transform>();
            PersonMovement unitScript = unit.GetComponent<PersonMovement>();

            // Z Pos
            float entranceNumber = Mathf.Floor(Random.value * numberOfEntrances);
            if(entranceNumber == numberOfEntrances) { entranceNumber--; }
            float depthPos = entranceNumber * entranceSpacing;
            float maxDepth = entranceSpacing * (numberOfEntrances - 1);
            depthPos -= maxDepth / 2;

            // X Pos
            float side = Random.value < 0.5f ? 1 : -1;
            float xPos = side * horizontalDistance;

            // Total Position
            unitTransform.position = new Vector3(xPos, personYPosition, depthPos);

            // Rotation
            unitTransform.eulerAngles = new Vector3(0, side * 90, 0);

            // Initial direction
            unitScript.SetInitialDirection(new Vector3(side * -1, 0, 0));

            unit.SetActive(true);
        }
	}

}
