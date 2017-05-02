using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSum : MonoBehaviour {

    TextMesh selection;
    GenerateEquation generator;    
    public int roundsToPlay;

	// Use this for initialization
	void Start () {        
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateEquation>();
        selection = gameObject.GetComponent<TextMesh>();
		
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
