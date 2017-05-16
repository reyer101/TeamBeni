using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class GameUtils {

    public static string lastLevel = "";
    public static bool safeToPlay = true;

    public static void loadWinScreen()
    {
        SceneManager.LoadScene("WinScreen");        
    }

	
}
