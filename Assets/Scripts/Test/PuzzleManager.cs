using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

    private float timer = 0f;
    private float delay = .5f;

    [Header("Puzzle 1")]
    public int amountHit;
    public bool puzzle1Solved;

    GameObject instrument;
    Light beamLight;

    [SerializeField]
    ParticleSystem lightBeam;
    ParticleSystem.MainModule lightBeamMain;
    [SerializeField]
    Color oneHit;
    [SerializeField]
    Color twoHit;
    [SerializeField]
    Color threeHit;

    [Header("Puzzle 2")]
    public bool puzzle2Solved;
    public bool hitByLight;
    
    [SerializeField]
    RaycastLightBeamP2 instrument2Ray;
    [SerializeField]
    GameObject door;
    [SerializeField]
    ParticleSystem lightBeamP2;

    void Start () {
        DontDestroyOnLoad(gameObject);

        if (lightBeam == null)
            lightBeam = GameObject.FindGameObjectWithTag("Instrument").transform.Find("LightBeam").GetComponent<ParticleSystem>();

        if (instrument == null)
            instrument = lightBeam.transform.parent.gameObject;

        if (beamLight == null)
            beamLight = lightBeam.transform.Find("Point Light").GetComponent<Light>();

        beamLight.gameObject.SetActive(false);

        lightBeamMain = lightBeam.main;
    }

    private void Update()
    {
        timer += Time.fixedDeltaTime;

        if(timer >= delay){
            if (!puzzle1Solved)
                ConditionsP1();
            else
                FinishP1();

            if (!puzzle2Solved && puzzle1Solved)
                ConditionsP2();
            else if (puzzle2Solved)
                FinishP2();

            timer = 0f;
        }
    }

    IEnumerator WaitToCheckPuzzles(){
        yield return new WaitForSeconds(2);
        CheckPuzzles();
    }

    private void CheckPuzzles()
    {
        if (!puzzle1Solved)
            ConditionsP1();
        else
            FinishP1();

        if (!puzzle2Solved && puzzle1Solved)
            ConditionsP2();
        else if (puzzle2Solved)
            FinishP2();
    }

    public void ConditionsP1()
    {
        switch (amountHit)
        {
            case 0: lightBeam.Stop();
                    beamLight.gameObject.SetActive(false);
                    break;

            case 1: lightBeam.Play();
                    beamLight.gameObject.SetActive(true);
                    beamLight.color = Color.red;
                    //lightBeamMain.startColor = oneHit;
                    break;

            case 2: lightBeam.Play();
                    beamLight.color = Color.yellow;
                    //lightBeamMain.startColor = twoHit;
                    break;

            case 3: lightBeam.Play();
                    beamLight.color = Color.green;
                    instrument.GetComponent<RaycastLightBeam>().startRaycast = true;
                    //lightBeamMain.startColor = threeHit;
                    break;
        }
    }

    private void FinishP1()
    {
        StartCoroutine(StopLightBeam());
    }

    void ConditionsP2()
    {
        if (lightBeamP2 == null)
        {
            lightBeamP2 = FindObjectOfType<RaycastLightBeamP2>().transform.Find("LightBeam").GetComponent<ParticleSystem>();
        }

        if (hitByLight)
        {
            if(!lightBeamP2.isPlaying)
                lightBeamP2.Play();

            if (instrument2Ray != null)
            {
                instrument2Ray.startRaycast = true;
            }
            else
            {
                instrument2Ray = FindObjectOfType<RaycastLightBeamP2>();
            }
        } else if (puzzle1Solved && !puzzle2Solved)
        {
            if (lightBeamP2.isPlaying)
                lightBeamP2.Stop();

            if (instrument2Ray != null)
                instrument2Ray.startRaycast = false;
        } else
        {
            if (lightBeamP2.isPlaying)
                lightBeamP2.Stop();
        }
    }

    void FinishP2()
    {
        if(lightBeamP2.isPlaying)
            lightBeamP2.Stop();

        if (door != null)
            door.SetActive(false);
        else
            door = GameObject.FindGameObjectWithTag("PuzzleReward");
    }

    IEnumerator StopLightBeam()
    {
        yield return new WaitForSeconds(2);
        lightBeam.Stop();
        beamLight.enabled = false;
    }
}
