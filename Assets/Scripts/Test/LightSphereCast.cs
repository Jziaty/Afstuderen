using UnityEngine;

public class LightSphereCast : MonoBehaviour {

    [SerializeField]
    Light spotLight;

    [SerializeField]
    float sphereCastRadius = 1;
    float sphereCastDistance;
    
    private void Start()
    {
        if (spotLight == null)
            spotLight = GetComponent<Light>();

        sphereCastDistance = spotLight.range;
    }

    void Update()
    {
        RaycastHit hit;

        Vector3 p1 = transform.position + transform.forward;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, sphereCastRadius, transform.forward, out hit, sphereCastDistance))
        {
            // TODO: Check for instrument, if all required spotlights find the instrument create a focussed light out of the instrument.
        }
    }
}
