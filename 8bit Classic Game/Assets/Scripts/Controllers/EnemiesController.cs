using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    //List of Enemies
    private List<GameObject> enemies;

	// Use this for initialization
	void Start ()
    {
        enemies = new List<GameObject>();
    }

    //Register Enemy
    public void registerEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    //De-Register Enemy
    public void deRegisterEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0) ControllerManager.Instance.sceneController.portal.SetActive(true);
    }

    //Get List of Enemies
    public List<GameObject> getEnemies()
    {
        return enemies;
    }
}
