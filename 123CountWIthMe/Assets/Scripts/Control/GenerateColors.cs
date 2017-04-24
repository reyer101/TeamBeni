using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateColors : MonoBehaviour {

    public static TextMesh colorText;

    Quaternion colorRotation;
    Vector2 colorPosition1, colorPosition2, colorPosition3;
    Vector2[] colorPositions;
    string[] colors = new string[4] { "Blue", "Green", "Yellow", "Red" };  //Initializes color array
    string[] shuffledColors;
    public int roundsToPlay;
    public static int rounds = 0;
    bool levelOver = false;
    public float promptAfterSeconds;
    float timestamp;

    // Use this for initialization
    void Start () {
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
        if(rounds == roundsToPlay && !levelOver)
        {
            Debug.Log("Level over, " + rounds + " rounds played.");  //Here we would return to a menu of some kind 
            levelOver = true;           
        }

        if (Input.GetMouseButton(0))
        {
            timestamp = Time.time + promptAfterSeconds;   //Resets inactivity timer on user click
        }

        if (Time.time >= timestamp)
        {
            Debug.Log("No click after " + promptAfterSeconds + " seconds. "   //Beni will prompt user here.
                + "Inset Beni voice prompt here.");
            timestamp = Time.time + promptAfterSeconds;
        }
    }

    public void generate() {
        deleteColors();  //Deletes all previous color instances
        shuffledColors = colors.OrderBy(n => System.Guid.NewGuid()).ToArray();   //Shuffles the color array

        int idx = (int) Random.Range(1.0f, 3.0f);
        colorText.text = shuffledColors[idx];    //Picks a random color from the chosen collors to act as the correct color choice
        
        for(int i = 0; i<3; ++i) {       
            
            Instantiate(Resources.Load(shuffledColors[i]), colorPositions[i], colorRotation); //Instantiates the colored objects
        }                                                             //with previously determined positions and rotation.

    }

    void deleteColors() {
        foreach (GameObject obj in GameObject.FindObjectsOfType  //For every GameObject in the scene.
            (typeof (GameObject)))
        {       
            if(colors.Contains(obj.tag))          //Destroy every object with a tag that is a color
            {
                Destroy(obj);
            }
        }
    }
}
