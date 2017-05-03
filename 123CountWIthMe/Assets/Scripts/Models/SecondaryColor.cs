using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryColor {

    public string[] colorMix = new string[2];

    public SecondaryColor(string color)
    {
        switch(color)
        {
            case "Orange":
                colorMix[0] = "Red";
                colorMix[1] = "Yellow";
                break;
            case "Purple":
                colorMix[0] = "Blue";
                colorMix[1] = "Red";
                break;
            case "Green":
                colorMix[0] = "Blue";
                colorMix[1] = "Yellow";
                break;
        }
    }

	
}
