using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    [SerializeField]
    private Transform targetLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            other.transform.position = targetLocation.position;
        }
    }
}
