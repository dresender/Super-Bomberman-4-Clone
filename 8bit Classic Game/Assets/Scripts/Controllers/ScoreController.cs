using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    //Control Variables
    private int score;

    //References
    public GameObject score100;

    //Spawn Score
    public void spawnScore(Vector2 position)
    {
        Instantiate(score100, position, Quaternion.identity);
    }
}
