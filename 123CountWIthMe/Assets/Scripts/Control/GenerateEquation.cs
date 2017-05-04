using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateEquation : MonoBehaviour {

    AudioSource beniAudio;
    TextMesh equation;    
    TextMesh[] guesses = new TextMesh[4];
    int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] shuffledNums, answerBank, shuffledAnswers;
    string eq;
    int a, b, rounds;
    public int roundsToPlay;
    public static int ans;

	// Use this for initialization
	void Start () {

        rounds = 0;
        beniAudio = GameObject.FindGameObjectWithTag("Beni").GetComponent<AudioSource>();
        equation = GameObject.FindGameObjectWithTag("AnswerChar1").GetComponent<TextMesh>();
        answerBank = new int[4];

        GameObject[] objs = GameObject.FindGameObjectsWithTag("GuessChar");

        for(int i = 0; i < 4; ++i)
        {
            guesses[i] = objs[i].GetComponent<TextMesh>();
        }

        makeEquation();     
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            makeEquation();
        }

        if (rounds > roundsToPlay)
        {
            Debug.Log("Game over");
            GameUtils.loadWinScreen();
        }

    }

    public void makeEquation() {
        int temp = 0;
        shuffledNums = nums.OrderBy(n => System.Guid.NewGuid()).ToArray();
        a = shuffledNums[(int)Random.Range(0.0f, 8.0f)];
        b = shuffledNums[(int)Random.Range(0.0f, 8.0f)];
        ans = a + b;
        eq = a + " + " + b + " = ";
        equation.text = eq;

        answerBank[0] = ans;           //Ensures the actual answer is in the answer bank

        if(ans < 7)
        {
            answerBank[1] = ans - 1;
            answerBank[2] = ans + 1;
            answerBank[3] = ans + 2;
        }
        else
        {
            answerBank[1] = ans - 2;
            answerBank[2] = ans + 1;
            answerBank[3] = ans + 2;
        }        
        
        shuffledAnswers = answerBank.OrderBy(n => System.Guid.NewGuid()).ToArray();

        for(int i = 0; i < 4; ++i)
        {
            guesses[i].text = shuffledAnswers[i].ToString();
        }

        ++rounds;

    }
}
