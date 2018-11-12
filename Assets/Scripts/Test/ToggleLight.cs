using UnityEngine;

public class ToggleLight : MonoBehaviour {

    [SerializeField]
    Light myLight;

    [SerializeField]
    float toggleDelay = 0.5f;
    float timer = 0.5f;

    bool playerInRange;

    private void Start()
    {
        if(myLight == null)
            myLight = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            //Debug.Log(other.transform.name + " in range.");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            //timer += Time.deltaTime;
            //Debug.Log(timer);

            //if (timer >= toggleDelay)
            //{
                if (Input.GetButtonDown("Interact"))
                {
                    ToggleMyLight();
                    timer = 0f;
                }
            //}
        }
    }

    public void ToggleMyLight()
    {
        if (myLight.isActiveAndEnabled)
        {
            myLight.enabled = false;                //Turn light off
            // TODO: Play sound of spotlight disabling
        }
        else
        {
            myLight.enabled = true;                 //Turn light on
            // TODO: Play sound of spotlight disabling
        }
    }
}
