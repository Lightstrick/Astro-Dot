using UnityEngine.Audio;
using System;
using UnityEngine;



//tutotial from brackeys ( https://www.youtube.com/watch?v=6OT43pvUyfY&ab_channel=Brackeys )
public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;




    
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    
}
