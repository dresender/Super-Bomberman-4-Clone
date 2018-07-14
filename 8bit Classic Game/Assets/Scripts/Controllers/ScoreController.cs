using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    //Control Variables
    public static int score;

    //References
    public GameObject score100;

    void Start()
    {
        score = 0;
    }

    //Spawn Score
    public void spawnScore(Vector2 position)
    {
        Instantiate(score100, position, Quaternion.identity);
        score += 100;        
    }
}
