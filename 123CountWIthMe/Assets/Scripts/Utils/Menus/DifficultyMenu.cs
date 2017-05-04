using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour {

    string scene, tag;
    

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene().name;
        tag = gameObject.tag;
		
	}
    
    void OnMouseDown() {
         
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
