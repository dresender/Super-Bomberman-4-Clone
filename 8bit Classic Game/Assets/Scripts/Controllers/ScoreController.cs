using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    //Control Variables
    public SpriteRenderer number_100;
    public SpriteRenderer number_1000;
    public Sprite[] numbers;
    private int lastScore;

    //References
    public GameObject score100;

    //Start Method
    private void Start()
    {
        lastScore = 0;
    }

    //Update Score
    private void Update()
    {
        if(ScoreData.score != lastScore)
        {
            number_100.sprite = numbers[ScoreData.score / 100];
            number_1000.sprite = numbers[(ScoreData.score % 100)];

            if (ScoreData.score >= 1000) number_1000.enabled = true;
            else number_1000.enabled = false;
        }
    }

    //Spawn Score
    public void spawnScore(Vector2 position)
    {
        Instantiate(score100, position, Quaternion.identity);
        ScoreData.score += 100;
    }
}
