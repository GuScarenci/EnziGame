using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {   
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        AudioAdjust();
    }

    public void Play(string name){
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
    }

    public void Stop(string name){
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Stop();
    }

    public void SoftPlay(string name){
        //if(MenuScript.volume != 0){
            StartCoroutine(SoftPlayCoroutine(name));
        //}
    }

    IEnumerator SoftPlayCoroutine(string name){
        yield return new WaitForSeconds(0.5f);
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 0;
        s.source.Play();
        while(s.source.volume < MenuScript.volumeMusic){
            yield return new WaitForSeconds(0.01f);
            s.source.volume += 0.01f;
        }
    }

    public void SoftStop(string name){
        //if(MenuScript.volume != 0){
            StartCoroutine(SoftStopCoroutine(name));
        //}
    }
    IEnumerator SoftStopCoroutine(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        while(s.source.volume > 0){
            yield return new WaitForSeconds(0.01f);
            s.source.volume -= 0.01f;
        }
        s.source.Stop();
    }

    public void AudioAdjust(){

        foreach(Sound s in sounds){
            if(s.source.loop == true){
                s.source.volume = MenuScript.volumeMusic;
            }else{
                s.source.volume = MenuScript.volumeGame;
            }
        }
    }

}
