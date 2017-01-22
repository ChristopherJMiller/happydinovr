using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {

    public AudioClip[] tracks;
    public bool random = false;
    private int currentTrack = 0;
    private AudioSource localAudioSource;

    void Start()
    {
        localAudioSource = GetComponent<AudioSource>();
        Random.InitState(Mathf.RoundToInt(Time.time * 10000000));
    }

    void Awake () {
        Random.InitState(Mathf.RoundToInt(Time.time * 10000000));
	}

    void FixedUpdate()
    {
        if (!localAudioSource.isPlaying)
        {
            if (random)
            {
                localAudioSource.PlayOneShot(tracks[Random.Range(0, tracks.Length - 1)]);
            }
            else
            {
                localAudioSource.PlayOneShot(tracks[currentTrack]);
                currentTrack++;
                if (currentTrack == tracks.Length)
                {
                    currentTrack = 0;
                }
            }
        }
    }
}
