using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateNumbers : MonoBehaviour {

    GameObject[] charObjects;
    int[] numbers;
    int[] shuffledNums;
    int randSeed;       

	// Use this for initialization
	void Start () {
        randSeed = (int) Random.Range(1.0f, 5.0f);
        numbers = new int[5] {randSeed, (randSeed+1), (randSeed+2), (randSeed+3), (randSeed+4) };
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
        randSeed = (int)Random.Range(1.0f, 5.0f);
        numbers = new int[5] { randSeed, (randSeed + 1), (randSeed + 2), (randSeed + 3), (randSeed + 4) };

        shuffledNums = numbers.OrderBy(n => System.Guid.NewGuid()).ToArray();
        for (int i = 0; i < charObjects.Length; ++i) {
            TextMesh num = charObjects[i].GetComponent<TextMesh>();
            num.text = shuffledNums[i].ToString();   

        }       
    }
}
