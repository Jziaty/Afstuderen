using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallManager : MonoBehaviour {

    private GameObject[] Halls;
    private int arraySize;
    private int currLastHall;
    private int offsetHall = 100;


	void Start () 
    {
        arraySize = transform.childCount;

        Halls = new GameObject[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            Halls[i] = transform.Find("Hall" + (i + 1)).gameObject;
        }

        currLastHall = arraySize;
	}
	
    public void SpawnNextHall()
    {
        switch(currLastHall)
        {
            case 1: Halls[1].transform.position -= new Vector3(offsetHall, 0f, 0f);
                    break;

            case 2: Halls[2].transform.position -= new Vector3(offsetHall, 0f, 0f);
                    break;

            case 3: Halls[0].transform.position -= new Vector3(offsetHall, 0f, 0f);
                    break;
        }
    }
}
