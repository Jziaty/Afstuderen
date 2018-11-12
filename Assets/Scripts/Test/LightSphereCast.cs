using UnityEngine;

public class LightSphereCast : MonoBehaviour {

    [SerializeField]
    PuzzleManager puzzleManager;

    [SerializeField]
    Light spotLight;

    [SerializeField]
    float sphereCastRadius = 1;
    float sphereCastDistance;
    bool amountAdded;

    private void Start()
    {
        if (spotLight == null)
            spotLight = GetComponent<Light>();

        if (puzzleManager == null)
            puzzleManager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<PuzzleManager>();

        sphereCastDistance = spotLight.range;
    }

    void Update()
    {
        RaycastHit hit;

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 9;
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
        if (Physics.SphereCast(transform.position, sphereCastRadius, transform.forward, out hit, sphereCastDistance, layerMask))
        {
            //Debug.DrawRay(transform.position, transform.forward, Color.blue);
            //Debug.Log(hit.transform.name + "Amount added?: " + amountAdded);
            if (!amountAdded && hit.transform.CompareTag("Instrument"))
            {
                //Debug.Log("Instrument Found!");
                AddToAmountHit();
            }
            
        } else if (amountAdded && hit.transform == null)
        {
            Debug.Log("Instrument not found");
            SubtractOffAmountHit();
        }
    }

    void AddToAmountHit()
    {
        puzzleManager.amountHit++;
        amountAdded = true;
    }

    void SubtractOffAmountHit()
    {
        puzzleManager.amountHit--;
        amountAdded = false;
    }
}
