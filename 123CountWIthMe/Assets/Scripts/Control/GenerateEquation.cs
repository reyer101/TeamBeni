using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
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
    float promptAfterSeconds, timestamp;

    // Use this for initialization
    IEnumerator Start()
    {
        GameUtils.safeToPlay = true;
        promptAfterSeconds = 15.0f;
        timestamp = promptAfterSeconds;
        rounds = 0;
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();
        equation = GameObject.FindGameObjectWithTag("AnswerChar1").GetComponent<TextMesh>();
        answerBank = new int[4];

        GameObject[] objs = GameObject.FindGameObjectsWithTag("GuessChar");

        for(int i = 0; i < 4; ++i)
        {
            guesses[i] = objs[i].GetComponent<TextMesh>();
        }

        beniAudio.Play();
        yield return new WaitForSeconds(3.5f);

        makeEquation();     
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!GameUtils.safeToPlay)
        {
            StopCoroutine("playAudio");
        }
        if (rounds > roundsToPlay)
        {            
            GameUtils.lastLevel = SceneManager.GetActiveScene().name;
            GameUtils.loadWinScreen();
        }

        if (Input.GetMouseButton(0))
        {
            timestamp = Time.time + promptAfterSeconds;   //Resets inactivity timer on user click
        }

        if (Time.time >= timestamp)
        {

            beniAudio.clip = (AudioClip)Resources.Load(Constants.aNumbersPath + "SolveProblem");  
            beniAudio.Play();

            timestamp = Time.time + promptAfterSeconds;
        }

    }

    public void makeEquation() {
        ++rounds;
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


        StopCoroutine("playAudio");        
        StartCoroutine("playAudio");
    }

    public IEnumerator playAudio()
    {
        beniAudio.clip = (AudioClip)Resources.Load(Constants.aNumbersPath + a);
        beniAudio.Play();        
        yield return new WaitForSeconds(1.0f);
        beniAudio.clip = (AudioClip)Resources.Load(Constants.aNumbersPath + "Plus");
        beniAudio.Play();        
        yield return new WaitForSeconds(1.25f);
        beniAudio.clip = (AudioClip)Resources.Load(Constants.aNumbersPath + b);
        beniAudio.Play();        
        yield return new WaitForSeconds(1.0f);
        beniAudio.clip = (AudioClip)Resources.Load(Constants.aNumbersPath + "Equals");
        beniAudio.Play();

    }
}
