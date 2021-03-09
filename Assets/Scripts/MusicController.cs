using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public bool isPlaying;

    [SerializeField] private AudioClip[] _audioClips = new AudioClip[5];
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TimeController _timeController;

    private bool _waitingToPlay;

    void Update()
    {
        isPlaying = audioSource.isPlaying || _waitingToPlay;
    }

    public void Play(int _audioId)
    {
        audioSource.Stop();
        audioSource.clip = _audioClips[_audioId];
        audioSource.loop = _audioId == 5;
        StartCoroutine(nameof(PlayInTwoSec));
    }

    private IEnumerator PlayInTwoSec()
    {
        _waitingToPlay = true;
        yield return new WaitForSeconds(_timeController.TIME_OFFSET_FOR_MUSIC_STARTS);
        
        audioSource.Play();
        _waitingToPlay = false;
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public AudioClip GetAudioClip(int id)
    {
        return _audioClips[id];
    }
}
