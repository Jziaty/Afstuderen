using UnityEngine;

public class LightSphereCast : MonoBehaviour {

    [SerializeField]
    PuzzleManager puzzleManager;

    [SerializeField]
    Light spotLight;
    
    public enum COLORLIGHT
    {
        RED,
        GREEN,
        BLUE
    }
    [SerializeField]
    private COLORLIGHT colorLight = COLORLIGHT.RED;

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
        
        int layerMask = 1 << 9;
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
        if (Physics.SphereCast(transform.position, sphereCastRadius, transform.forward, out hit, sphereCastDistance, layerMask))
        {
            //Debug.DrawRay(transform.position, transform.forward, Color.blue);
            //Debug.Log(hit.transform.name + "Amount added?: " + amountAdded);
            if (!puzzleManager.puzzle1Solved && !amountAdded && spotLight.enabled && hit.transform.CompareTag("Instrument"))
            {
                //Debug.Log("Instrument Found!");
                AddToAmountHit();
                //ProcessAndSendColor();
            }

            if(puzzleManager.puzzle1Solved && !puzzleManager.puzzle2Solved && spotLight.enabled && hit.transform.CompareTag("Instrument"))
            {
                puzzleManager.hitByLight = true;
            }
            
        } else if (!puzzleManager.puzzle1Solved && amountAdded && hit.transform == null)
        {
            //Debug.Log("Instrument not found");
            SubtractOffAmountHit();
        } else if (!puzzleManager.puzzle2Solved && hit.transform == null)
        {
            puzzleManager.hitByLight = false;
        }
    }

    //void ProcessAndSendColor()
    //{
    //    if (colorLight == COLORLIGHT.RED)
    //        puzzleManager.ChangeBeamColor(new Color(255,0,0,1));
        
    //    if(colorLight == COLORLIGHT.GREEN)
    //        puzzleManager.ChangeBeamColor(new Color(0, 255, 0, 1));

    //    if(colorLight == COLORLIGHT.BLUE)
    //        puzzleManager.ChangeBeamColor(new Color(0, 0, 255, 1));
    //}

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
