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
                    SceneManager.LoadScene("ColorsEasy");
                }
                else
                {
                    SceneManager.LoadScene("ColorsAdvanced");
                }
                break;
            case "LetterMenu":
                if (tag == "Beginner")
                {
                    SceneManager.LoadScene("LettersEasy");
                }
                else
                {
                    SceneManager.LoadScene("LettersAdvanced");
                }
                break;
            case "NumberMenu":
                if (tag == "Beginner")
                {
                    SceneManager.LoadScene("NumbersEasy");
                }
                else
                {
                    SceneManager.LoadScene("NumbersAdvanced");
                }
                break;
        }

    }		
}
