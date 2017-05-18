using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GenerateWord : MonoBehaviour {

    AudioSource beniAudio;
    TextMesh[] answerBank = new TextMesh[4];    
    TextMesh wordBlank;
    int rounds = 0;
    public int roundsToPlay;
    char[] word, shuffledAnswers;
    string[] shuffledWords;
    public static char ans;
    string prevWord;
    float promptAfterSeconds, timestamp;
    List<char> answers = new List<char>();
    public static bool levelOver;

    // Use this for initialization
    void Start () {
        levelOver = false;
        promptAfterSeconds = 15.0f;
        timestamp = promptAfterSeconds + Time.time;
        prevWord = "";
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();        
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GuessChar");        
        wordBlank = GameObject.FindGameObjectWithTag("AnswerChar1").GetComponent<TextMesh>();

        for (int i = 0; i < 4; ++i)
        {
            answerBank[i] = objs[i].GetComponent<TextMesh>();
        }

        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();
        makeWord();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(rounds == roundsToPlay)
        {
            levelOver = true;            
        }

        if (Input.GetMouseButton(0))
        {
            timestamp = Time.time + promptAfterSeconds;   //Resets inactivity timer on user click
        }

        if (Time.time >= timestamp)
        {

            beniAudio.clip = (AudioClip)Resources.Load(Constants.aLettersInstruct + prevWord);  //Playes color prompt
            beniAudio.Play();

            timestamp = Time.time + promptAfterSeconds;
        }
    }

    public void makeWord() {
        ++rounds;
        answers.Clear();
        shuffledWords = Constants.words.OrderBy(n => System.Guid.NewGuid()).ToArray();
        int idx = (int)Random.Range(0.0f, 14.0f);        

        while (shuffledWords[idx] == prevWord)
        {            
            idx = (int)Random.Range(0.0f, 14.0f);
        }

        word = shuffledWords[idx].ToCharArray();
        prevWord = shuffledWords[idx];
        idx = (int) Random.Range(0.0f, word.Length - 1);
        ans = word[idx];
        word[idx] = '_';
        wordBlank.text = new string(word);
        answers.Insert(0, ans);     
        
        for(int i = 1; i < 4; ++i)
        {
            if(isVowel(ans))      //If the answer is a vowel
            {
                answers.Insert(i, getRandVowel());                                                          
            }           
            else           //Answer is a consonant
            {
                answers.Insert(i, getRandConst());                
            }
        } 

        shuffledAnswers = answers.OrderBy(n => System.Guid.NewGuid()).ToArray();

        for(int i = 0; i < 4; ++i)
        {
            answerBank[i].text = shuffledAnswers[i].ToString();
        }

        beniAudio.clip = (AudioClip) Resources.Load(Constants.aLettersInstruct + prevWord.Trim());        
        beniAudio.Play();

    }

    char getRandVowel() {        
        
        foreach(char letter in Constants.vowels)
        {
            if(!answers.Contains(letter))
            {
                return letter;
            }
        }

        return ' ';
    }

    char getRandConst() {
        
        int guessIdx = (int)Random.Range(0.0f, 20.0f);
        while (answers.Contains(Constants.consonants[guessIdx]))  //Will generate a consonant not already in the answers array
        {
            guessIdx = (int)Random.Range(0.0f, 20.0f);
        }

        return Constants.consonants[guessIdx];

    }  

    bool isVowel(char c) {
        return Constants.vowels.Contains(c);
    }

}
