using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    string tag;

	// Use this for initialization
	void Start () {
        tag = gameObject.tag; tag = gameObject.tag;

    }	

    void OnMouseDown() {       

        switch(tag)
        {
            case "Color":
                SceneManager.LoadScene("ColorMenu");
                break;
            case "Letter":
                SceneManager.LoadScene("LetterMenu");
                break;
            case "Number":
                SceneManager.LoadScene("NumberMenu");
                break;
        }        

    }
}
