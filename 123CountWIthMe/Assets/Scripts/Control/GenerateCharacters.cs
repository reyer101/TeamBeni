using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateCharacters : MonoBehaviour {

    public AudioSource beniAudio;
    GameObject[] charObjects;
    TextMesh answer1, answer2, answer3, answer4, answer5;
    TextMesh[] answers;
    public bool genNumbers, genLetters;
    public static int[] numbers;
    public static int currentNumIdx;    
    List<int> shuffledNums;     
    int randSeed;
    public float promptAfterSeconds;
    float timestamp;      

	// Use this for initialization
	void Start () {
        currentNumIdx = 1;            
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();
              

        charObjects = GameObject.FindGameObjectsWithTag("GuessChar");
        timestamp = promptAfterSeconds;

        answer1 = GameObject.FindGameObjectWithTag("AnswerChar1")
            .GetComponent<TextMesh>();
        answer2 = GameObject.FindGameObjectWithTag("AnswerChar2")
            .GetComponent<TextMesh>();
        answer3 = GameObject.FindGameObjectWithTag("AnswerChar3")  //Assigns AnswerChar TextMeshes 
            .GetComponent<TextMesh>();
        answer4 = GameObject.FindGameObjectWithTag("AnswerChar4")
            .GetComponent<TextMesh>();
        answer5 = GameObject.FindGameObjectWithTag("AnswerChar5")
            .GetComponent<TextMesh>();

        answers = new TextMesh[5] { answer1, answer2, answer3,    //Creates ordered array of AnswerChar TextMeshes
            answer4, answer5 };

        if(genNumbers) {
            generateNumbers();   //Randomly generates guess numbers and populates answers.
        }

        if(genLetters) {
            generateLetters();
        }        
        

    }
	
	// Update is called once per frame
	void Update () {        

        if (Input.GetMouseButton(0)) {
            timestamp = Time.time + promptAfterSeconds;   //Resets inactivity timer on user click
        }

        if (Time.time >= timestamp)
        {
            if(genLetters)
            {
                beniAudio.clip = (AudioClip)Resources.Load(Constants.promptPathL + "Idle");  //Letters idle prompt
                beniAudio.Play();
            }
            else if(genNumbers)
            {
                beniAudio.clip = (AudioClip)Resources.Load(Constants.promptPathN + "Idle");  //Numbers idle prompt
                beniAudio.Play();
            }
            Debug.Log("No click after " + promptAfterSeconds + " seconds. " //Beni will prompt user here.
                + "Inset Beni voice prompt here.");            
            timestamp = Time.time + promptAfterSeconds;
        }

    }

    void generateNumbers() {
        randSeed = (int)Random.Range(1.0f, 5.0f);       //Returns a random integer between 1 and 5

        numbers = new int[5] { randSeed, (randSeed + 1), (randSeed + 2),  //Creates an array of 5 ordered numbers between 1 and 9
            (randSeed + 3), (randSeed + 4) };

        shuffledNums = numbers.OrderBy(n => System.Guid.NewGuid())  //Shuffles the ordered numbers array
            .ToList();

        shuffledNums.Remove(randSeed);

        for (int i = 0; i < charObjects.Length; ++i) {
            TextMesh num = charObjects[i].GetComponent<TextMesh>();
            num.text = shuffledNums[i].ToString();       //Assigns the number values from the shuffled array to the guess characters

            answers[i].text = numbers[i].ToString();     //Assigns the answer TextMeshes the value of each number in ascending order
        }

        answers[4].text = numbers[4].ToString();    
    }

    void generateLetters()
    {
        randSeed = (int) Random.Range(1.0f, 22.0f);       //Returns a random integer between 1 and 5
        Debug.Log(randSeed);

        numbers = new int[5] { randSeed, (randSeed + 1), (randSeed + 2),  //Creates an array of 5 ordered numbers between 1 and 22
            (randSeed + 3), (randSeed + 4) };

        shuffledNums = numbers.OrderBy(n => System.Guid.NewGuid())  //Shuffles the ordered numbers array
            .ToList();

        shuffledNums.Remove(randSeed);

        for (int i = 0; i < charObjects.Length; ++i)
        {
            TextMesh num = charObjects[i].GetComponent<TextMesh>();

            num.text = numToString(shuffledNums[i], true);       //Translates number values from shuffled array to letters and assigns to guess chars

            answers[i].text = numToString(numbers[i], true);     //Assigns the answer TextMeshes the value of each number in ascending order
        }
        answers[4].text = numToString(numbers[4], true);
    }

    public static string numToString(int number, bool isCaps)  //Utility function converting an integer to a string representation
    {
        char c = (char)((isCaps ? 65 : 97) + (number - 1));
        return c.ToString();
    }
}
