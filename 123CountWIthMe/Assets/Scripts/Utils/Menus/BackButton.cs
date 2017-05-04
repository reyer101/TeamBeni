using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour {

    string scene;

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene().name;       
		
	}

    void OnMouseDown() {

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        if(scene.Contains("Menu"))
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }
        else if(scene.Contains("Letters"))
        {
            SceneManager.LoadSceneAsync("LetterMenu");
        }
        else if (scene.Contains("Numbers"))
        {
            SceneManager.LoadSceneAsync("NumberMenu");
        }
        else if(scene.Contains("Colors"))
        {
            SceneManager.LoadSceneAsync("ColorMenu");
        }
        else
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }

    }
}
