using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    //References
    [HideInInspector]
    public BombController bombController;
    [HideInInspector]
    public EnemiesController enemiesController;
    [HideInInspector]
    public TimeController timeController;
    [HideInInspector]
    public ScoreController scoreController;
    [HideInInspector]
    public SceneController sceneController;

    //Singleton Instance Variable
    private static ControllerManager instance;
    public static ControllerManager Instance
    {
        get
        {
            return instance;
        }
    }

    //On Object Awake
    private void Awake()
    {
        //Check Singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    //On Object Destroy (Safeguard)
    public void OnDestroy()
    {
        instance = null;
    }

    //Start Method
    private void Start()
    {
        bombController = this.GetComponent<BombController>();
        enemiesController = this.GetComponent<EnemiesController>();
        timeController = this.GetComponent<TimeController>();
        scoreController = this.GetComponent<ScoreController>();
        sceneController = this.GetComponent<SceneController>();
    }
}
