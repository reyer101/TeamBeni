using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class SelectColorA : MonoBehaviour {

    GenerateColorsA generator;
    AudioSource beniAudio;
    string colorText;
    SpriteRenderer rend;
    Color tint;
    bool clicked;

	// Use this for initialization
	void Start () {
        clicked = false;
        beniAudio = GameObject.FindGameObjectWithTag("BeniAudio").GetComponent<AudioSource>();
        tint = new Color();
        ColorUtility.TryParseHtmlString("#D5D5D5FF", out tint);
        rend = GetComponent<SpriteRenderer>();      
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateColorsA>();
		
	}

    void Update()
    {
        if(GenerateColorsA.colorsDirty)
        {
            rend.color = Color.white;
        }

    }

    void OnMouseEnter()
    {
        rend.color = tint;
    }

    void OnMouseExit()
    {
        if(!clicked)
        {
            rend.color = Color.white;
        }       
    }

    void OnMouseDown() {
        clicked = true;
        colorText = gameObject.tag;        
        if (GenerateColorsA.color.colorMix.Contains(colorText))
        {
            GenerateColorsA.selectedColors.Add(colorText);
        }
        else
        {
            //Chosen color is not one of the two mixing colors
            GenerateColorsA.selectedColors.Clear();
            beniAudio.clip = (AudioClip) Resources.Load(Constants.genPath + "Oops");
            beniAudio.Play();
        }

        if(GenerateColorsA.selectedColors.Count == 2)
        {
            GenerateColorsA.colorsDirty = true;
            clicked = false;                        
            if (!GenerateColorsA.levelOver)
            {               
                GenerateColorsA.selectedColors.Clear();                
                generator.makeColors();                
            }
            else
            {
                GenerateColorsA.selectedColors.Clear();
                GameUtils.lastLevel = SceneManager.GetActiveScene().name;
                GameUtils.loadWinScreen();
            }       
            
        }
    }
}
