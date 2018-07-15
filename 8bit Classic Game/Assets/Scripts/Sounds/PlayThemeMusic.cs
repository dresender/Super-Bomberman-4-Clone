using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayThemeMusic : MonoBehaviour
{
    private AudioManager aManager;
    void Start()
    {
        aManager = FindObjectOfType<AudioManager>();
        aManager.Play("Theme Music");
    }
}