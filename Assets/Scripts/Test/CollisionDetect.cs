using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour {

    [SerializeField]
    RayCastInteract raycastScript;

    private void Start()
    {
        if (raycastScript == null)
            raycastScript = Camera.main.GetComponent<RayCastInteract>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("HardSurface"))
        {
            //Debug.Log("Collision with " + collision.transform.name);
            raycastScript.DropObject();
        }
    }
}
