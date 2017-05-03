using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectColorA : MonoBehaviour {

    GenerateColorsA generator;

	// Use this for initialization
	void Start () {

        generator = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateColorsA>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
