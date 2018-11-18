using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFlicker : MonoBehaviour {

    [SerializeField]
    float minIntensity;
    [SerializeField]
    float maxIntensity;
    [SerializeField]
    float flickerDelay;
    
    Light flameLight;
    float timer;
    bool startFlicker;

    private void OnEnable()
    {
        startFlicker = true;
    }

    void Start () {
        flameLight = GetComponent<Light>();
	}
	
	void Update () {
        if (startFlicker)
        {
            timer += Time.deltaTime;

            if(timer >= flickerDelay)
            {
                flameLight.intensity = Random.Range(minIntensity, maxIntensity);
                timer = 0f;
            }
        }
            
	}

    private void OnDisable()
    {
        startFlicker = false;
    }
}
