using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

    public static string promptPath = "AudioClips/BColors/Clip";
    public static string genPath = "AudioClips/General/Clip";
    public static string bluePath = "BlueItems/";
    public static string greenPath = "GreenItems/";
    public static string purplePath = "PurpleItems/";
    public static string redPath = "RedItems/";
    public static string yellowPath = "YellowItems/";
    public static string promptPathL = "AudioClips/BLetters/Clip";
    public static string promptPathN = "AudioClips/BNumbers/Clip";
    public static string scubaPath = "ScubaFrames/";

    public static char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
    public static char[] consonants = new char[21] { 'b', 'c', 'd', 'f', 'g',
        'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
    public static string[] words = new string[15] {"ball", "bat", "bear", "boat",
        "car", "cat", "dog", "frog", "hat", "rat", "shoe", "sock", "star", "sun", "tree" };
}
