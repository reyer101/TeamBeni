using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSum : MonoBehaviour {

    AudioSource beniAudio;
    TextMesh selection;
    Renderer rend;
    GenerateEquation generator;        
    public int roundsToPlay;

	// Use this for initialization
	void Start () {
        GameUtils.safeToPlay = true;
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();        
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
            GameUtils.safeToPlay = true;
            generator.makeEquation();

        } 
        else
        {           
            beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Oops");
            beniAudio.Play();
            GameUtils.safeToPlay = false;
            //Incorrect audio here
        }        
    }
}
