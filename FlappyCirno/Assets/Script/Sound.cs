using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Sound : MonoBehaviour, ISoundController
{

    private bool _music = true;
    private bool _sfx = true;
    private Settings settings;
    private AudioClip musicClip;
    private AudioClip jumpClip;
    private AudioClip pointClip;
    private AudioClip dieClip;
    private AudioSource audioSourceMusic;
    private AudioSource audioSourceDie;
    private AudioSource audioSourceJump;
    private AudioSource audioSourcePoint;
    public bool music
    {
        get { return _music; }
        set
        { 
            _music = value;
            if (!audioSourceMusic.isPlaying)
                audioSourceMusic.Play();
            audioSourceMusic.mute = !value;
        } 
    }
    public bool sfx
    {
        get { return _sfx; }
        set
        {
            _sfx = value;
            audioSourcePoint.mute = !value;
            audioSourceJump.mute = !value;
            audioSourceDie.mute = !value;
        }

    }
    [Inject]
    private void Construct(Settings settings)
    {
        this.settings = settings;
        
    }
    private void Awake()
    {
        audioSourcePoint = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSourceJump = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSourceDie = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSourceMusic = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSourceMusic.loop = true;
        audioSourcePoint.loop = false;
        audioSourceJump.loop = false;
        audioSourceDie.loop = false;
        audioSourceMusic.playOnAwake = false;
        audioSourcePoint.playOnAwake = false;
        audioSourceJump.playOnAwake = false;
        audioSourceDie.playOnAwake = false;
    }
    private void Start()
    {
        musicClip = settings._musicClip;
        jumpClip = settings._jumpClip;
        pointClip = settings._pointClip;
        dieClip = settings._dieClip;
        audioSourcePoint.clip = pointClip;
        audioSourceJump.clip = jumpClip;
        audioSourceDie.clip = dieClip;
        audioSourceMusic.clip = musicClip;
        audioSourceMusic.volume = settings._volume;
        audioSourcePoint.volume = settings._volume;
        audioSourceJump.volume = settings._volume;
        audioSourceDie.volume = settings._volume;
        music = settings._music;
        sfx = settings._sfx;
    }
    public void PlayDie()
    {
        audioSourceDie.Play();
    }

    public void PlayJump()
    {
        audioSourceJump.Play();
    }

    public void PlayPoint()
    {
        audioSourcePoint.Play();
    }
}
