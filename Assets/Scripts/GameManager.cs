using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //bool activateNextScene;

    Scene sceneToSetActive;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //SceneManager.sceneLoaded += SetNextScene;

        LoadNextScene();
    }

    public void LoadNextScene(/*bool setactive*/)
    {
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
        {
            //activateNextScene = setactive;

            //Scene _nextscene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);

            sceneToSetActive = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);

            //if (setactive)
            //    SetNextScene(_nextscene);
        }
        else
        {
            Debug.LogWarning("No next scene found, this should be the last scene");
        }
    }

    public void SetNextScene(/*Scene nxtscene, LoadSceneMode loadmode*/)
    {
        SceneManager.SetActiveScene(sceneToSetActive);
    }

    public void UnloadPrevScene()
    {
        if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - 1) != null)
        {
            Scene _nextscene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - 1);

            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);            
        }
        else
        {
            Debug.LogWarning("No prev scene found, this should be the first scene");
        }
    }
}
