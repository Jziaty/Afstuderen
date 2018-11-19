using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNextHall : MonoBehaviour {

    HallManager hallManager;
    bool called;

    private void Start()
    {
        hallManager = transform.parent.parent.GetComponent<HallManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!called){
                hallManager.SpawnNextHall();
                called = true;
            } else {
                gameObject.SetActive(false);
            }
        }
    }
}
