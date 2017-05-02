using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSum : MonoBehaviour {

    TextMesh selection;
    GenerateEquation generator;
    int answer, rounds;
    public int roundsToPlay;

	// Use this for initialization
	void Start () {
        rounds = 1;
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateEquation>();
        selection = gameObject.GetComponent<TextMesh>();
		
	}
	
	// Update is called once per frame
	void Update () {
        answer = GenerateEquation.ans;      
		
	}

    void OnMouseDown() {
        if (selection.text == answer.ToString())
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
