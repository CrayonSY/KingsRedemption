using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        
    }

    public void PlaySE(int _audioId)
    {
        audioSource.Stop();
        audioSource.clip = audioClips[_audioId];
        audioSource.Play();
    }

}
