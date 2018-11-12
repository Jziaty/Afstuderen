using UnityEngine;

public class RayCastInteract : MonoBehaviour {

    [SerializeField]
    Transform itemHolder;
    [SerializeField]
    int throwForce = 10;
    bool canHold = true;

    Transform objInHold;

    private void Start()
    {
        if (itemHolder == null)
            itemHolder = transform.Find("ItemHolder");
    }

    void Update () {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit: " + hit.transform.name);
            if (canHold && Input.GetButtonDown("Interact") && hit.transform.GetComponent<Rigidbody>())
            {
                HoldObject(hit.transform);
                canHold = false;
            }
        }

        if (!canHold && Input.GetButtonDown("Fire1"))
        {
            ThrowObject();
        }
    }

    void HoldObject(Transform objectToPickup)
    {
        Rigidbody _itemrb = objectToPickup.GetComponent<Rigidbody>();

        _itemrb.useGravity = false;
        _itemrb.isKinematic = true;

        objectToPickup.parent = itemHolder;
        objectToPickup.position = itemHolder.position;
        objectToPickup.localPosition = new Vector3(0, 0, 0);
        objectToPickup.localRotation = Quaternion.identity;

        objectToPickup.gameObject.AddComponent<CollisionDetect>();

        objInHold = objectToPickup;

        canHold = false;
    }

    void ThrowObject()
    {
        if(objInHold != null)
        {
            Rigidbody _itemrb = objInHold.GetComponent<Rigidbody>();

            _itemrb.useGravity = true;
            _itemrb.isKinematic = false;

            Destroy(objInHold.gameObject.GetComponent<CollisionDetect>());

            objInHold.parent = null;

            _itemrb.AddForce(transform.forward * throwForce);

            canHold = true;
        }
    }

    public void DropObject()
    {
        if (objInHold != null)
        {
            Rigidbody _itemrb = objInHold.GetComponent<Rigidbody>();

            _itemrb.useGravity = true;
            _itemrb.isKinematic = false;

            Destroy(objInHold.gameObject.GetComponent<CollisionDetect>());

            objInHold.parent = null;

            canHold = true;
        }
    }

}
