using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLetter : MonoBehaviour {
    AudioSource beniAudio;
    TextMesh selection;
    GenerateWord generator;
    Renderer rend;

	// Use this for initialization
	void Start () {
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();
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

    IEnumerator OnMouseDown()
    {
        if (selection.text == GenerateWord.ans.ToString())
        {
            //Correct audio here  
            yield return new WaitForSeconds(.3f);                      
            generator.makeWord();

        }
        else
        {
            //Incorrect audio here
        }
    }
}
