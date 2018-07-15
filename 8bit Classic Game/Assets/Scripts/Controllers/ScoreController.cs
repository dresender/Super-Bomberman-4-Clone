using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    //Control Variables
    public static int score;
    public SpriteRenderer number_100;
    public SpriteRenderer number_1000;
    public Sprite[] numbers;

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

        number_100.sprite = numbers[score / 100];
        number_1000.sprite = numbers[(score % 100)];

        if (score >= 1000) number_1000.enabled = true;
        else number_1000.enabled = false;
    }
}
