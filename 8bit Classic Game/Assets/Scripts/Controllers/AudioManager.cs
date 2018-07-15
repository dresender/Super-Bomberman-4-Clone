using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private string currentSceneName;

    //Singleton Instance Variable
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    //Setting up the sounds
    void Awake ()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        //Building library
        foreach (Sound s in sounds)
        {
            //For each sound we are looking for, add the audiosource component
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    //Simple method to play musics that are managed by the script Manager
    public void Play(string name)
    {
        //Find the sound in the sounds array, where sound.name is equal to the passed name
        Sound s = Array.Find(sounds, sound => sound.name == name);

        //Play the sound source stored above
        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }  

    public bool finishedPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.time >= s.clip.length) return true;
        else return false;
    }
    
    public bool IsPlaying(string name)
    {
        bool isPlaying;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        isPlaying = s.source.isPlaying;

        return isPlaying;
    }
}
