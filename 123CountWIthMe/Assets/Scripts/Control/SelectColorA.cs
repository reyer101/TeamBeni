using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectColorA : MonoBehaviour {

    GenerateColorsA generator;
    string colorText;
    SpriteRenderer rend;
    Color tint;

	// Use this for initialization
	void Start () {
        tint = new Color();
        ColorUtility.TryParseHtmlString("#848484FF", out tint);
        rend = GetComponent<SpriteRenderer>();      
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateColorsA>();
		
	}

    void OnMouseEnter()
    {
        rend.color = tint;
    }

    void OnMouseExit()
    {
        rend.color = Color.white;
    }

    void OnMouseDown() {
        colorText = gameObject.tag;
        Debug.Log(colorText + " clicked!");
        if (GenerateColorsA.color.colorMix.Contains(colorText))
        {
            GenerateColorsA.selectedColors.Add(colorText);
        }
        else
        {
            GenerateColorsA.selectedColors.Clear();
        }

        if(GenerateColorsA.selectedColors.Count == 2)
        {
            Debug.Log("Yay you won!");
            GenerateColorsA.selectedColors.Clear();
            generator.makeColors();
        }
    }
}
