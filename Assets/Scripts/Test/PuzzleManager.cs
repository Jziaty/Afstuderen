using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {

    [Header("Puzzle 1")]
    [SerializeField]
    ParticleSystem lightBeam;
    ParticleSystem.MainModule lightBeamMain;
    [SerializeField]
    Color oneHit;
    [SerializeField]
    Color twoHit;
    [SerializeField]
    Color threeHit;
    public int amountHit;

    void Start () {
        DontDestroyOnLoad(gameObject);

        if (lightBeam == null)
            lightBeam = GameObject.FindGameObjectWithTag("Instrument").transform.Find("LightBeam").GetComponent<ParticleSystem>();
        else
            lightBeamMain = lightBeam.main;
    }

    private void Update()
    {
        ConditionsP1();
    }

    public void ConditionsP1()
    {
        switch (amountHit)
        {
            case 0: lightBeam.Stop();
                    break;

            case 1: lightBeam.Play();
                    lightBeamMain.startColor = oneHit;
                    break;

            case 2: lightBeam.Play();
                    lightBeamMain.startColor = twoHit;
                    break;

            case 3: lightBeam.Play();
                    lightBeamMain.startColor = threeHit;
                    // Open the door and notice the player he completed the puzzle.
                    break;
        }
    }
}
