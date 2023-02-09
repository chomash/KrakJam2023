using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    [SerializeField] private List<AudioClip> music;
    private List<AudioClip> avaliableClips;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioLowPassFilter lowPass;
    private AudioClip lastPlayed;
    [Range(0.0f, 1.0f)]
    public float musicEffect = 1.0f;
    private float baseVolume;
    private int cutoffFrequency = 22000;
    
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
        lowPass.cutoffFrequency = cutoffFrequency * musicEffect * musicEffect * musicEffect;
        source.volume = baseVolume * musicEffect;
        if (!source.isPlaying)
        {
            avaliableClips = new List<AudioClip>(music);
            avaliableClips.Remove(lastPlayed);

            PlayRandomMusic();    
        }


    }


    private void PlayRandomMusic()
    {
        int rng = Random.Range(0, avaliableClips.Count);
        lastPlayed = avaliableClips[rng];
        source.clip = lastPlayed;
        source.Play();
    }
}
