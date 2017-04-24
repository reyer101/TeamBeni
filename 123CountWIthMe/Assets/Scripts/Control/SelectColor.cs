using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectColor : MonoBehaviour {
    GenerateColors generator;
    string color;       

	// Use this for initialization
	void Start () {
        color = gameObject.tag;
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateColors>();   //Used to generate new rounds
	}
	
	// Update is called once per frame
	void Update () {        
		
	}

    void OnMouseDown() {
        if(validateColor())
        {
            ++GenerateColors.rounds;     //Increments rounds when the user makes a correct color choice.
        }
    }

    bool validateColor() {
        string correctColor = GenerateColors.colorText.text;

        if (correctColor == color)
        {
            Debug.Log("You are correct!"); //Beni would tell the user that their choice is correct.
            generator.generate(); 
            return true;           
        }
       
        Debug.Log("Sorry, but this isn't " + correctColor); //Beni would tell the user that their choice is incorrect.
        return false;
    }
}
