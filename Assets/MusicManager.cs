using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

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

    [SerializeField] private List<AudioClip> music;
    private List<AudioClip> avaliableClips;
    [SerializeField] private AudioSource source;
    private AudioClip lastPlayed;

    private void Start()
    {
        avaliableClips = new List<AudioClip>(music);
        PlayRandomMusic();

    }

    private void Update()
    {
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
