using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatTracking : MonoBehaviour {

    public float losePercentage;
    public GameObject loseCanvas;
    public GameObject sittingPerson;
    public GameObject timeTracker;
    public float sitterY;
    public float sitChance;
    public float sitThreshold;
    public float distanceFromCenter;
    public int seatsPerRow;
    public float spaceBetweenSeats;
    public float[] seatLocations;

    private bool[][] occupancy;
    private int loseNumber;
    private int seatsOccupied;

	void Start () {
        occupancy = new bool[seatLocations.Length][];
        for(int i = 0; i < occupancy.Length; i++)
        {
            occupancy[i] = new bool[seatsPerRow * 2];
        }

        loseNumber = Mathf.FloorToInt(seatLocations.Length * seatsPerRow * 2 * losePercentage);
        seatsOccupied = 0;
	}

    void Update() {
        float sitProb = sitChance * Time.deltaTime;

        GameObject[] people = GameObject.FindGameObjectsWithTag("Person");
        foreach (GameObject person in people)
        {
            float personZ = person.GetComponent<Transform>().position.z;
            bool seated = false;

            for(int i = 0; i < occupancy.Length; i++)
            {
                if(Mathf.Abs(seatLocations[i] - personZ) <= sitThreshold)
                {
                    for (int j = 0; j < seatsPerRow * 2; j++)
                    {
                        if (!occupancy[i][j])
                        {
                            if (Random.value < sitProb)
                            {
                                SeatPerson(person, i, j);
                                seated = true;
                            }
                        }

                        if (seated)
                        {
                            break;
                        }
                    }
                }

                if (seated)
                {
                    break;
                }
            }
        }
	}

    private void SeatPerson(GameObject person, int row, int seat)
    {
        Destroy(person);
        GameObject sitter = Instantiate(sittingPerson);
        Transform sitterTransform = sitter.GetComponent<Transform>();

        // X
        float sitterX;
        if(seat < seatsPerRow)
        {
            sitterX = -(seat * spaceBetweenSeats + distanceFromCenter);
        }
        else
        {
            sitterX = (seat - seatsPerRow) * spaceBetweenSeats + distanceFromCenter;
        }

        // Z
        float sitterZ = seatLocations[row];

        sitterTransform.position = new Vector3(sitterX, sitterY, sitterZ);
        sitter.SetActive(true);

        occupancy[row][seat] = true;

        seatsOccupied++;
        if(seatsOccupied >= loseNumber)
        {
            Lose();
        }
    }

    private void Lose()
    {
        loseCanvas.SetActive(true);
    }

    public float GetFilledPercentage()
    {
        return (float)seatsOccupied / loseNumber;
    }

}
