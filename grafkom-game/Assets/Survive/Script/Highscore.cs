using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    // Text object that display highscore
    public Text value;

    // GameObject of score
    public GameObject HighscoreObject;

    // The script from the score
    public ScoreScript Script;

    void Awake()
    {
        // Get object
        HighscoreObject = GameObject.FindGameObjectsWithTag("Score")[0] as GameObject;
        
        // Get value
        Script = HighscoreObject.GetComponent<ScoreScript>();

        // Get the TextMeshPro

        // Change text
        value.text = Script.scoreValue.ToString();
    }
}
