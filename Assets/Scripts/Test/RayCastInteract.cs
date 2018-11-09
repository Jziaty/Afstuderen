using UnityEngine;

public class RayCastInteract : MonoBehaviour {
    	
	void Update () {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit: " + hit.transform.name );
        }
    }
}
