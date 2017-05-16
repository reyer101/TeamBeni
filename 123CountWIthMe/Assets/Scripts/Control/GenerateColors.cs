using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class GenerateColors : MonoBehaviour {       
    public static TextMesh colorText;

    public AudioSource beniAudio;
    Quaternion colorRotation;
    Vector2 colorPosition1, colorPosition2, colorPosition3;
    Vector2[] colorPositions;
    string[] colors = new string[5] { "Blue", "Green", "Yellow", "Red", "Purple" };  //Initializes color array
    string[] colorPaths = new string[5] { Constants.bluePath, Constants.greenPath,
        Constants.yellowPath, Constants.redPath, Constants.purplePath };  //Initializes array of string paths to different 
    string[] shuffledColorPaths;
    int[] objNums = new int[3] { 1, 2, 3 }; //color folders
    int[] shuffledObjNums;
    string chosenColor, prevColor;
    public int roundsToPlay;
    public static int rounds = 0;
    bool levelOver = false;
    public float promptAfterSeconds;
    float timestamp;    

    // Use this for initialization
    IEnumerator Start () {
        GameUtils.safeToPlay = true;
        prevColor = "";   //Initializes previous color to the empty string since the level is just starting.
        beniAudio = GameObject.FindGameObjectWithTag("Beni").GetComponent<AudioSource>();
        yield return new WaitForSeconds(4.5f);       
        beniAudio.Play();        

        timestamp = promptAfterSeconds;
        colorText = GameObject.FindGameObjectWithTag("GuessChar").GetComponent<TextMesh>(); //Gets reference to color TextMesh

        colorRotation = GameObject.FindGameObjectWithTag("Blue").transform.rotation;  //Gets default rotation for colored objects

        colorPosition1 = GameObject.FindGameObjectWithTag("Blue").transform.position;        
        colorPosition2 = GameObject.FindGameObjectWithTag("Green").transform.position; //Gets 3 preset locations for colored objects       
        colorPosition3 = GameObject.FindGameObjectWithTag("Red").transform.position;
        

        colorPositions = new Vector2[3] {colorPosition1, colorPosition2, colorPosition3 }; //Array of preset color spawn positions

        generate();    //Generates the first round of random colors
    }
	
	// Update is called once per frame
	void Update () {        
        if(rounds == roundsToPlay)
        {
            Debug.Log("Level over, " + rounds + " rounds played.");  //Here we would return to a menu of some kind 
            rounds = 0;
            GameUtils.lastLevel = SceneManager.GetActiveScene().name;
            GameUtils.loadWinScreen();          
        }        

        if (Input.GetMouseButton(0))
        {
            timestamp = Time.time + promptAfterSeconds;   //Resets inactivity timer on user click
        }

        if (Time.time >= timestamp)
        {
            if(GameUtils.safeToPlay)
            {
                Debug.Log("Safe to play");                
                beniAudio.Play();
            }            
            
            timestamp = Time.time + promptAfterSeconds;
        }
    }

    public void generate() {
        deleteColors();  //Deletes all previous color instances
        shuffledColorPaths = colorPaths.OrderBy(n => System.Guid.NewGuid()).ToArray();   //Shuffles the color path array
        shuffledObjNums = objNums.OrderBy(n => System.Guid.NewGuid()).ToArray();  //Shuffles the object numbers array

        int objNum = (int) Random.Range(1.0f, 3.0f);  //Picks random number bettween 1 and 3 to decide which colored object is chosen
        int chosenIdx = (int)Random.Range(1.0f, 3.0f); //Random idx for chosen color                
        
        for(int i = 0; i<3; ++i) {       
            if(i == chosenIdx) {
                GameObject obj = (GameObject) Resources.Load(shuffledColorPaths[i] + shuffledObjNums[i]);
                chosenColor = obj.tag;

                if(chosenColor == prevColor) {   //If the chosen color is the same as the previous color, generate again.
                    generate();
                    return;
                }
                colorText.text = chosenColor;
                beniAudio.clip = (AudioClip) Resources.Load(Constants.promptPath + chosenColor);
                prevColor = chosenColor;
            }
            Instantiate(Resources.Load(shuffledColorPaths[i] + shuffledObjNums[i]), colorPositions[i], colorRotation); 
                                                                      //Instantiates the colored objects
        }                                                             //with previously determined positions and rotation.

        beniAudio.Play();
    }

    void deleteColors() {
        foreach (GameObject obj in GameObject.FindObjectsOfType  //For every GameObject in the scene.
            (typeof (GameObject)))
        {       
            if(colors.Contains(obj.tag))          //Destroy every object with a tag that is a color
            {
                Debug.Log(obj.GetType());
                Destroy(obj);
            }
        }
    }    
}
