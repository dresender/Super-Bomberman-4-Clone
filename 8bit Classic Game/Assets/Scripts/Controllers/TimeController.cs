using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    //References
    public SpriteRenderer number_minutes;
    public SpriteRenderer number_seconds_decimal;
    public SpriteRenderer number_seconds_unit;
    public Sprite[] numbers;

    //Public Variables
    public int maxTime;

    //Private Variables
    private bool timeRunning;
    private float currentTime;
    private float durationPausedTime;

	// Use this for initialization
	void Start ()
    {
        timeRunning = true;
        currentTime = maxTime;
    }
	
    //Get Time State
    public bool getTimeState()
    {
        return timeRunning;
    }

    //Adjust Time in UI
    private void setTimeUI()
    {
        number_minutes.sprite = numbers[(int)currentTime / 60];
        number_seconds_decimal.sprite = numbers[((int)currentTime % 60) / 10];
        number_seconds_unit.sprite = numbers[(int)currentTime % 10];
    }

    //Pause Time
    public void pauseTime(float time)
    {
        timeRunning = false;
        durationPausedTime = time;
        List<GameObject> enemies = ControllerManager.Instance.enemiesController.getEnemies();
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<EnemyAnimation>().pauseAnimation();
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (!timeRunning)
        {
            durationPausedTime -= Time.deltaTime;
            if (durationPausedTime <= 0.5f)
            {
                List<GameObject> enemies = ControllerManager.Instance.enemiesController.getEnemies();
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].GetComponent<EnemyAnimation>().flashSprite();
                }

                if (durationPausedTime <= 0)
                {
                    timeRunning = true;
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].GetComponent<EnemyAnimation>().resumeAnimation();
                    }
                }
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            setTimeUI();
            if (PlayerState.Instance != null && currentTime <= 0) PlayerState.Instance.killPlayer();
        }
    }
}
