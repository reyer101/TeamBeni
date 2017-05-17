using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButton : MonoBehaviour {

    string scene;
    AudioSource clickSound;
    SpriteRenderer rend;
    Color tint;

    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        tint = new Color();
        ColorUtility.TryParseHtmlString("#D5D5D5FF", out tint);
        scene = SceneManager.GetActiveScene().name;
        clickSound = gameObject.GetComponent<AudioSource>();     
		
	}
    void OnMouseEnter()
    {
        rend.color = tint;
    }

    void OnMouseExit()
    {
        rend.color = Color.white;
    }

    IEnumerator OnMouseDown() {

        clickSound.Play();
        yield return new WaitForSeconds(.2f);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        if(scene.Contains("Menu") && !scene.Contains("Main"))
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
        else if (scene.Contains("Main"))
        {
            SceneManager.LoadSceneAsync("TitleScreen");
        }
        else
        {
            SceneManager.LoadSceneAsync("MainMenu");            
        }

    }
}
