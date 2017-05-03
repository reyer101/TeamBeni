using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectColorA : MonoBehaviour {

    GenerateColorsA generator;
    string colorText;

	// Use this for initialization
	void Start () {        
        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateColorsA>();
		
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
