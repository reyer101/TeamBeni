using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLetter : MonoBehaviour {

    TextMesh selection;
    GenerateWord generator;

	// Use this for initialization
	void Start () {

        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateWord>();
        selection = gameObject.GetComponent<TextMesh>();
		
	}	

    void OnMouseDown()
    {
        if (selection.text == GenerateWord.ans.ToString())
        {
            //Correct audio here
            generator.makeWord();

        }
        else
        {
            //Incorrect audio here
        }
    }
}
