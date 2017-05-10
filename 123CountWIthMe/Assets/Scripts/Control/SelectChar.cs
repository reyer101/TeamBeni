using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour {

    AudioSource beniAudio;
    BoxCollider collider;
    Renderer rend;    
    TextMesh answer1, answer2, answer3, answer4, answer5, character;
    TextMesh[] answersRender;
    int[] numbers;       

	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider>();
        rend = GetComponent<Renderer>();
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();

        character = gameObject.GetComponent<TextMesh>();
        numbers = GenerateCharacters.numbers;              

        answer1 = GameObject.FindGameObjectWithTag("AnswerChar1")
            .GetComponent<TextMesh>();
        answer2 = GameObject.FindGameObjectWithTag("AnswerChar2")
            .GetComponent<TextMesh>();
        answer3 = GameObject.FindGameObjectWithTag("AnswerChar3")  //Assigns AnswerChar Renderers 
            .GetComponent<TextMesh>();
        answer4 = GameObject.FindGameObjectWithTag("AnswerChar4")
            .GetComponent<TextMesh>();
        answer5 = GameObject.FindGameObjectWithTag("AnswerChar5")
            .GetComponent<TextMesh>();

        answersRender = new TextMesh[5] { answer1, answer2, answer3,    //Creates ordered array of AnswerChar Renderers
            answer4, answer5 };
    }
	
	// Update is called once per frame
	void Update () {
        numbers = GenerateCharacters.numbers;        

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
        //Debug.Log(character.text + " selected");
        if(validateNums())
        {
            Destroy(character);
            Destroy(collider);          
            
        }
    }

    bool validateNums() { 
        try
        {
            if (Int32.Parse(character.text) == numbers[GenerateCharacters.currentNumIdx])
            {  //Answer correct
               //Debug.Log(GenerateNumbers.currentNumIdx);
                answersRender[GenerateCharacters.currentNumIdx].color = Color.black;    //Show the number text if the answer is correct
                GenerateCharacters.currentNumIdx += 1;                          //Increment currentNumIdx  

                Debug.Log(character.text + " is correct!");
                beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Correct");
                beniAudio.Play();              


                if (GenerateCharacters.currentNumIdx == 5)
                {
                    //At this point the level will be won.
                    Debug.Log("Yay you won!");
                    GameUtils.loadWinScreen();

                }

                return true;
            }

            beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Oops");
            beniAudio.Play();
            return false;   //Guess is incorrect

        }
        catch(FormatException e)
        {
            return validateLetters();
        }        

    }

    bool validateLetters() {
        if(character.text == GenerateCharacters.numToString
            (numbers[GenerateCharacters.currentNumIdx], true)) {

            answersRender[GenerateCharacters.currentNumIdx].color = Color.blue;    //Show the number text if the answer is correct
            GenerateCharacters.currentNumIdx += 1;                          //Increment currentNumIdx 

            Debug.Log(character.text + " is correct!");
            beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Correct");
            beniAudio.Play();

            if (GenerateCharacters.currentNumIdx == 5)
            {
                //At this point the level will be won.
                Debug.Log("Yay you won!");
                GameUtils.loadWinScreen();

            }

            return true;

        }

        beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Oops");
        beniAudio.Play();
        return false;  //Guess is incorrect
    }
    
}
