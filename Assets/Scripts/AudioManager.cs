using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [SerializeField] private List<AudioClip> music;
    private List<AudioClip> avaliableClips;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioLowPassFilter lowPass;
    private AudioClip lastPlayed;
    [Range(0.0f, 1.0f)]
    public float musicEffectGoTo = 0.4f;
    public float musicEffectChangeSpeed = 0.3f;
    private bool turnEffectOn = false, turnEffectOff = false;
    private float currentMusicEffect = 1.0f;

    private float baseVolume;
    private int cutOffFrequency = 22000;
    private float fraction = 0;
    
    private void Awake() //singleton
    {
        DontDestroyOnLoad(this);

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }



    private void Start()
    {
        baseVolume = source.volume;
        avaliableClips = new List<AudioClip>(music);
        PlayRandomMusic();

    }

    private void Update()
    {
        if (turnEffectOn)
        {
            fraction += musicEffectChangeSpeed * Time.deltaTime;
            currentMusicEffect = Mathf.Lerp(1, musicEffectGoTo, fraction);
            if (fraction > 1)
            {
                turnEffectOn = false;
            }
        }

        if (turnEffectOff)
        {
            fraction += musicEffectChangeSpeed * Time.deltaTime;
            currentMusicEffect = Mathf.Lerp(musicEffectGoTo, 1, fraction);
            if (fraction > 1)
            {
                turnEffectOff = false;
            }
        }



        lowPass.cutoffFrequency = cutOffFrequency * currentMusicEffect * currentMusicEffect * currentMusicEffect;
        source.volume = baseVolume * currentMusicEffect;


        if (!source.isPlaying)
        {
            avaliableClips = new List<AudioClip>(music);
            avaliableClips.Remove(lastPlayed);

            PlayRandomMusic();    
        }



    }

    public void EffectOff()
    {
        fraction = 0;
        turnEffectOff = true;
    }

    public void EffectOn()
    {
        fraction = 0;
        turnEffectOn = true;
    }

    private void PlayRandomMusic()
    {
        int rng = Random.Range(0, avaliableClips.Count);
        lastPlayed = avaliableClips[rng];
        source.clip = lastPlayed;
        source.Play();
    }
}
