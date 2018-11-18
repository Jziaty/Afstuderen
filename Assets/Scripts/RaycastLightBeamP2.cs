using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastLightBeamP2 : MonoBehaviour {

    public bool startRaycast;

    PuzzleManager puzzleManager;

    [SerializeField]
    GameObject flame;

    private void Start()
    {
        if (puzzleManager == null)
            puzzleManager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<PuzzleManager>();
    }

    void Update ()
    {
        if (startRaycast)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.magenta);
                //Debug.Log("Did Hit: " + hit.transform.name);
                if (hit.transform.CompareTag("Logs"))
                {
                    flame.SetActive(true);
                    puzzleManager.puzzle2Solved = true;
                    startRaycast = false;
                }
            }
        }
    }
}
