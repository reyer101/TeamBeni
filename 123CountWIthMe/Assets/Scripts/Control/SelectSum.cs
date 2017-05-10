using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSum : MonoBehaviour {

    TextMesh selection;
    Renderer rend;
    GenerateEquation generator;    
    public int roundsToPlay;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();     
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateEquation>();
        selection = gameObject.GetComponent<TextMesh>();
		
	}

    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

    void OnMouseDown() {
        if (selection.text == GenerateEquation.ans.ToString())
        {
            //Correct audio here
            generator.makeEquation();

        } 
        else
        {
            //Incorrect audio here
        }        
    }
}
