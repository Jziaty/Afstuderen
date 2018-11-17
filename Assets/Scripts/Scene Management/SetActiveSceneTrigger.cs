using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveSceneTrigger : MonoBehaviour {

    GameManager gm;
    bool called;

    private void Start()
    {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!called && other.transform.CompareTag("Player"))
        {
            gm.SetNextScene();
            called = true;
        }
    }
}
