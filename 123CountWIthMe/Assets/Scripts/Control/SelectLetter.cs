using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLetter : MonoBehaviour {

    TextMesh selection;
    GenerateWord generator;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateWord>();
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
