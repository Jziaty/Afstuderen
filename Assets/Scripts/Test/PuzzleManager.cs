using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

    [Header("Puzzle 1")]
    public int amountHit;
    public bool puzzleSolved;

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

    //[SerializeField]
    //Color beamColor;

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
        if (!puzzleSolved)
            ConditionsP1();
        else
            FinishP1();
    }

    //public void ChangeBeamColor(Color color)
    //{
        //FAILED ATTEMPT TO COMBINE COLORS.
        //Vector4 _color = new Vector4(color.r, color.g, color.b, color.a);
        //Vector4 _beamColor = new Vector4(beamColor.r, beamColor.g, beamColor.b, beamColor.a);

        //Vector4 _result = _color + _beamColor;
        //Color _resultColor = new Color(_result.x, _result.y, _result.z, _result.w);

        //lightBeamMain.startColor = _resultColor;
    //}

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

    IEnumerator StopLightBeam()
    {
        yield return new WaitForSeconds(2);
        lightBeam.Stop();
        beamLight.enabled = false;
    }
}
