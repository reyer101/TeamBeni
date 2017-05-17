using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectColor : MonoBehaviour {
    AudioSource beniAudio;
    SpriteRenderer rend; 
    GenerateColors generator;
    string color, correctColor;
    bool rightPlaying, wrongPlaying;
    Color tint;
    Coroutine playAudio;      

	// Use this for initialization
	void Start () {
        GameUtils.safeToPlay = true;        
        tint = new Color();
        ColorUtility.TryParseHtmlString("#D5D5D5FF", out tint);
        rend = GetComponent<SpriteRenderer>();
        string correctColor = GenerateColors.colorText.text;
        beniAudio = GameObject.FindGameObjectWithTag("Beni").GetComponent<AudioSource>();
        color = gameObject.tag;
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateColors>();   //Used to generate new rounds        
	}
	
	// Update is called once per frame
	void Update () {
        correctColor = GenerateColors.colorText.text;
        GameUtils.safeToPlay = !beniAudio.isPlaying;
    }

    void OnMouseDown() {
        if(validateColor())
        {
            if(!GenerateColors.levelOver)
            {
                ++GenerateColors.rounds;     //Increments rounds when the user makes a correct color choice.               
                generator.generate();
            }
            else
            {
                GameUtils.lastLevel = SceneManager.GetActiveScene().name;
                GameUtils.loadWinScreen();
            }               
        }
        else
        {            
            if(beniAudio.clip != (AudioClip) Resources.Load(Constants.genPath + "Oops"))
            {
                StartCoroutine("playWrongAudio");
            }  
            
            if(!beniAudio.isPlaying)
            {
                StartCoroutine("playWrongAudio");
            }      
                        
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

        return correctColor == color;       
    }

    IEnumerator playWrongAudio()
    {       
        beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Oops");
        beniAudio.Play();                    //Loads and plays incorrect clip
        yield return new WaitForSeconds(4.5f);       
        beniAudio.clip = (AudioClip)Resources.Load(Constants.promptPath + correctColor);
        beniAudio.Play();       //Loads and plays color prompt after incorrect clip is played        
    }

    IEnumerator playCorrectAudio()
    {
        
        beniAudio.clip = (AudioClip)Resources.Load(Constants.genPath + "Correct");
        beniAudio.Play();               //Loads and plays correct clip                
        
        yield return new WaitForSeconds(4.0f);  //Gives time for the audio to play before generating next round.
        generator.generate();        
    }
}
