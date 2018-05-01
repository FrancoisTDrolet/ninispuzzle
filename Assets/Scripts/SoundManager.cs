using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource music;
    public AudioSource efx;
    public static SoundManager instance = null;
    
    public void startMusic()
    {
        music.Play();
    }

    public void stopMusic()
    {
        music.Stop();
    }

    public void playSingle(AudioClip clip)
    {
        efx.clip = clip;
        efx.Play();
    }

	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);	
	}
}
