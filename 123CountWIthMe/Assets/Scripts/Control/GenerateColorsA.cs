using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateColorsA : MonoBehaviour {

    Quaternion secondayRotation;
    Vector2 secondaryPosition;
    Vector2[] primaryPositions;
    Vector2[] shuffledPositions;
    GameObject[] primaryColors = new GameObject[3];
    GameObject secondaryColor;
    AudioSource beniAudio;
    public static SecondaryColor color;
    public static string chosenColor;
    string prevColor;    
    int rounds;
    public static HashSet<string> 
        selectedColors = new HashSet<string>();
    public int roundsToPlay;
    float promptAfterSeconds, timestamp;
    public static bool levelOver, colorsDirty;   

    // Use this for initialization
    void Start () {
        colorsDirty = false;
        levelOver = false;
        promptAfterSeconds = 15.0f;
        timestamp = promptAfterSeconds;
        prevColor = "";
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();
        primaryPositions = new Vector2[3];
        secondaryPosition = GameObject.FindGameObjectWithTag("Secondary").transform.position;
        secondayRotation = GameObject.FindGameObjectWithTag("Secondary").transform.rotation;

        primaryColors[0] = GameObject.FindGameObjectWithTag("Blue");
        primaryColors[1] = GameObject.FindGameObjectWithTag("Red");
        primaryColors[2] = GameObject.FindGameObjectWithTag("Yellow");

        for(int i = 0; i < 3; ++i)
        {
            primaryPositions[i] = primaryColors[i].transform.position;
        }        
        makeColors();      

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
            
            beniAudio.clip = (AudioClip) Resources.Load(Constants.aColorsInstruct + chosenColor);  //Playes color prompt
            beniAudio.Play();           
            
            timestamp = Time.time + promptAfterSeconds;
        }
    }

    public void makeColors() {        
        ++rounds;
        deleteSecondary();
        shuffleColors();
        int idx = (int) Random.Range(0.0f, 3.0f);        

        while(prevColor == Constants.secondaryColors[idx])  //Ensures the new chosen color is not the same as the previous
        {
            idx = (int)Random.Range(0.0f, 3.0f);            
        }

        chosenColor = Constants.secondaryColors[idx];
        prevColor = chosenColor;        

        secondaryColor = (GameObject) Instantiate(Resources.Load(Constants.secondaryPath + chosenColor),
            secondaryPosition, secondayRotation);

        color = new SecondaryColor(chosenColor);

        beniAudio.clip = (AudioClip)Resources.Load(Constants.aColorsPath + chosenColor);
        beniAudio.Play();   //Play prompt for selected secondary color
        GenerateColorsA.colorsDirty = false;
    }

    void shuffleColors() {
        shuffledPositions = primaryPositions.OrderBy(n => System.Guid.NewGuid()).ToArray();

        for(int i = 0; i < 3; ++i)
        {
            primaryColors[i].transform.position = shuffledPositions[i];
        }
    }

    void deleteSecondary() {
        if(secondaryColor != null)
        {
            Destroy(secondaryColor);
        }
    }
}
