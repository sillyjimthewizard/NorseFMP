using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _SoundManager : MonoBehaviour
{
    public static _SoundManager instance;
    private Transform SoundTrash;
 
    

    [Header("Audio")]
    [SerializeField]
    private AudioClip music;
    public AudioClip Buttons;

    [Header("Particles")]
    [SerializeField]
    private GameObject TestParticle;
   

    private void Awake()
    {
        instance = this;
        SoundTrash = GameObject.Find("TrashManager").transform;
    }

    private void Start()
    {
        PlayMusic();


    }


    public void PlaySound(AudioClip audioClip)
    {
        GameObject newSoundObject = new GameObject("SFX"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = audioClip; //assigns the audio clip from the argument
        //audioSource.clip = collision; //assigns the audio clip from the argument
        audioSource.Play(); //Plays the sound
        Destroy(newSoundObject, audioClip.length); //Destroys the object after the sound completes playing    

    }

    public void PlaySoundLocal(AudioClip audioClip)
    {
        GameObject newSoundObject = new GameObject("SFX"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(_GameManager.Instance.CurrentBoss.transform); //Moves object into the trash folder
        newSoundObject.transform.position = _GameManager.Instance.CurrentBoss.transform.position;
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = audioClip; //assigns the audio clip from the argument
        audioSource.maxDistance = 1f;
        audioSource.minDistance = 2f;
        audioSource.spatialBlend = 1;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        //audioSource.clip = collision; //assigns the audio clip from the argument
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


    public void PlayMusic()
    {
        GameObject newSoundObject = new GameObject("Music"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = music; //assigns the audio clip from the argument
        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.Play(); //Plays the sound

    }

    public void PlayParticle(GameObject Particle, Vector3 Position, float Duration)
    {
        GameObject NewParticle = Instantiate(Particle, Position, Quaternion.identity);
        NewParticle.transform.SetParent(SoundTrash);
        Destroy(NewParticle, Duration);
        

    }

    public void PlayButtonSound()
    {
        GameObject newSoundObject = new GameObject("SFX"); //Creates a new object in the heirachy
        newSoundObject.transform.SetParent(SoundTrash); //Moves object into the trash folder
        AudioSource audioSource = newSoundObject.AddComponent<AudioSource>(); //adds an audio source
        audioSource.clip = Buttons; //assigns the audio clip from the argument
        //audioSource.clip = collision; //assigns the audio clip from the argument
        audioSource.Play(); //Plays the sound
        Destroy(newSoundObject, Buttons.length); //Destroys the object after the sound completes playing    

    }

}