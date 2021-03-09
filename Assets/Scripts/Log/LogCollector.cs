using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCollector : MonoBehaviour
{
    [SerializeField] private MainController _mainController;
    [SerializeField] private TimeController _timeController;
    [SerializeField] private MusicController _musicController;
    [SerializeField] private ScoreManager _scoreManager;

    private int[] _bpm = { 122, 138, 135, 140, 143 };
    private Note[] _notes;
    private float _musicLength;
    private int _beats;
    private float _timeBetweenBeats;

    private const int _SPEED = 5;
    
    void Update()
    {
        //PutNote();
    }

    /*
    private void PutNote()
    {
        if (!_mainController.isPlayingGame) return;
        if (!Input.GetMouseButton(0)) return;
        float time = _timeController.time;
        Vector3 pos = Input.mousePosition;
        int index = (int)(time/_timeBetweenBeats);
        if (index >= 0 && index < _notes.Length) _notes[index].SetParameters(time, pos.x, pos.y);
    }
    
    public void Init()
    {
        _musicLength = _musicController.GetAudioClip(_scoreManager.difficulty).length;
        _beats = (int)(_musicLength / 60 * _bpm[_scoreManager.difficulty]);
        _notes = new Note[_SPEED * _beats];

        _timeBetweenBeats = _musicLength / _notes.Length;
        for(int i = 0; i < _notes.Length; i++)  _notes[i] = new Note((i+0.5f) * _timeBetweenBeats);
    }

    public Note[] GetNotes()
    {
        return _notes;
    }
    */
}
