using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateNumbers : MonoBehaviour {

    GameObject[] charObjects;
    int[] numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8};
    int[] shuffledNums;
    

	// Use this for initialization
	void Start () {
        shuffledNums = numbers.OrderBy(n => System.Guid.NewGuid()).ToArray();
        charObjects = GameObject.FindGameObjectsWithTag("Char");
        generateNumbers();

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.G)) {            
            generateNumbers();
        }
		
	}

    void generateNumbers() {
        shuffledNums = numbers.OrderBy(n => System.Guid.NewGuid()).ToArray();
        for (int i = 0; i < charObjects.Length; ++i) {
            TextMesh num = charObjects[i].GetComponent<TextMesh>();
            num.text = shuffledNums[i].ToString();   

        }
        

        
    }
}
