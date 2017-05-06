using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour {

    string scene;
    AudioSource clickSound;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene().name;
        clickSound = gameObject.GetComponent<AudioSource>();     
		
	}

        IEnumerator OnMouseDown() {

        clickSound.Play();
        yield return new WaitForSeconds(.2f);
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
