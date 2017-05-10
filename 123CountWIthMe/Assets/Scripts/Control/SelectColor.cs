using System.Collections;
using UnityEngine;

public class SelectColor : MonoBehaviour {
    AudioSource beniAudio;
    SpriteRenderer rend; 
    GenerateColors generator;
    string color, correctColor;
    Color tint;      

	// Use this for initialization
	void Start () {
        tint = new Color();
        ColorUtility.TryParseHtmlString("#484848FF", out tint);
        rend = GetComponent<SpriteRenderer>();
        string correctColor = GenerateColors.colorText.text;
        beniAudio = GameObject.FindGameObjectWithTag("Beni").GetComponent<AudioSource>();
        color = gameObject.tag;
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateColors>();   //Used to generate new rounds        
	}
	
	// Update is called once per frame
	void Update () {
        correctColor = GenerateColors.colorText.text;
    }

    IEnumerator OnMouseDown() {
        if(validateColor())
        {
            ++GenerateColors.rounds;     //Increments rounds when the user makes a correct color choice.
            yield return new WaitForSeconds(4.0f);  //Gives time for the audio to play before generating next round.            
            generator.generate();
        }
        else
        {
            yield return new WaitForSeconds(4.5f);
            beniAudio.clip = (AudioClip) Resources.Load(Constants.promptPath + correctColor);
            beniAudio.Play();       //Loads and plays color prompt after incorrect clip is played
        }
    }

    void OnMouseEnter()
    {
        rend.color = tint;
    }

    void OnMouseExit()
    {
        rend.color = Color.white;
    }

    bool validateColor() {        

        if (correctColor == color)
        {
            Debug.Log("You are correct!"); //Beni would tell the user that their choice is correct.
            beniAudio.clip = (AudioClip) Resources.Load(Constants.genPath + "Correct");
            beniAudio.Play();               //Loads and plays correct clip
             
            return true;           
        }
       
        Debug.Log("Sorry, but this isn't " + correctColor); //Beni would tell the user that their choice is incorrect.
        beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Oops");
        beniAudio.Play();                    //Loads and plays incorrect clip
        return false;
    }
}
