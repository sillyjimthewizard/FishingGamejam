using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SoundManager : MonoBehaviour
{
    public static S_SoundManager instance;
    private Transform SoundTrash;
    private AudioClip music;
    
   

    private void Awake()
    {
        instance = this;
        SoundTrash = GameObject.Find("SoundTrash").transform;
    }

    private void Start()
    {
        //PlayMusic(music);
    }


    public void PlaySound(AudioClip audioClip, float volume)
    {
        GameObject newSoundObject = new GameObject("SFX"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = audioClip; //assigns the audio clip from the argument
        //audioSource.clip = collision; //assigns the audio clip from the argument
        audioSource.volume = volume;
        audioSource.Play(); //Plays the sound
        Destroy(newSoundObject, audioClip.length); //Destroys the object after the sound completes playing    

    }


    public void PlaySoundAltered(AudioClip audioClip, float pitch)
    {
        GameObject newSoundObject = new GameObject("SFX"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = audioClip; //assigns the audio clip from the argument
        //Change stuff here
        audioSource.pitch = pitch;
        audioSource.Play(); //Plays the sound
        Destroy(newSoundObject, audioClip.length + 10.0f); //Destroys the object after the sound completes playing        
    }


    public void PlayMusic(AudioClip Music, float volume)
    {
        GameObject newSoundObject = new GameObject("Music"); //Creates a new object in the heirachy
        foreach (Transform child in SoundTrash.transform)
         {
             Destroy(child.gameObject);
         } 
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = Music; //assigns the audio clip from the argument
        audioSource.loop = true;
        audioSource.volume = volume;
        audioSource.Play(); //Plays the sound

    }

}