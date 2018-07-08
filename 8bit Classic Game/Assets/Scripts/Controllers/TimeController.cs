using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    //Public Variables
    public int maxTime;

    //Private Variables
    private int currentTime;
    private bool timeRunning;
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
		if(!timeRunning)
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
	}
}
