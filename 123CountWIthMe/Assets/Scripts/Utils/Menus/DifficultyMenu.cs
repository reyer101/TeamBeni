using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour {

    string scene, tag;
    AudioSource clickSound;
    Renderer rend;
    Color tint;   

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        tint = new Color();
        ColorUtility.TryParseHtmlString("#484848FF", out tint);
        scene = SceneManager.GetActiveScene().name;
        clickSound = gameObject.GetComponent<AudioSource>();
        tag = gameObject.tag;
		
	}

    void OnMouseEnter()
    {
        rend.material.color = tint;
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    void OnMouseDown() {
        clickSound.Play();
         
        switch(scene)
        {
            case "ColorMenu":
                if(tag == "Beginner")
                {
                    SceneManager.LoadSceneAsync("ColorsEasy");
                }
                else
                {
                    SceneManager.LoadSceneAsync("ColorsAdvanced");
                }
                break;
            case "LetterMenu":
                if (tag == "Beginner")
                {
                    SceneManager.LoadSceneAsync("LettersEasy");
                }
                else
                {
                    SceneManager.LoadSceneAsync("LettersAdvanced");
                }
                break;
            case "NumberMenu":
                if (tag == "Beginner")
                {
                    SceneManager.LoadSceneAsync("NumbersEasy");
                }
                else
                {
                    SceneManager.LoadSceneAsync("NumbersAdvanced");
                }
                break;
        }

    }		
}
