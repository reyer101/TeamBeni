using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour {

    AudioSource beniAudio;
    TextMesh character;
    Renderer answer1, answer2, answer3, answer4, answer5;
    Renderer[] answersRender;
    int[] numbers;       

	// Use this for initialization
	void Start () {
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();

        character = gameObject.GetComponent<TextMesh>();
        numbers = GenerateCharacters.numbers;              

        answer1 = GameObject.FindGameObjectWithTag("AnswerChar1")
            .GetComponent<Renderer>();
        answer2 = GameObject.FindGameObjectWithTag("AnswerChar2")
            .GetComponent<Renderer>();
        answer3 = GameObject.FindGameObjectWithTag("AnswerChar3")  //Assigns AnswerChar Renderers 
            .GetComponent<Renderer>();
        answer4 = GameObject.FindGameObjectWithTag("AnswerChar4")
            .GetComponent<Renderer>();
        answer5 = GameObject.FindGameObjectWithTag("AnswerChar5")
            .GetComponent<Renderer>();

        answersRender = new Renderer[5] { answer1, answer2, answer3,    //Creates ordered array of AnswerChar Renderers
            answer4, answer5 };
    }
	
	// Update is called once per frame
	void Update () {
        numbers = GenerateCharacters.numbers;        

    }

    IEnumerator OnMouseDown() {
        //Debug.Log(character.text + " selected");
        if(validateNums())
        {
            yield return new WaitForSeconds(4.0f);
        }
        else
        {
            yield return new WaitForSeconds(4.5f);
        }
        

    }

    bool validateNums() { 
        try
        {
            if (Int32.Parse(character.text) == numbers[GenerateCharacters.currentNumIdx])
            {  //Answer correct
               //Debug.Log(GenerateNumbers.currentNumIdx);
                answersRender[GenerateCharacters.currentNumIdx].enabled = true;    //Show the number text if the answer is correct
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

            answersRender[GenerateCharacters.currentNumIdx].enabled = true;    //Show the number text if the answer is correct
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
