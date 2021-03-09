using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class NoteLoading : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    public List<Note> notes = new List<Note>();
    private const float MIN_DISTANCE = 50;
    
    public void LoadNotes()
    {
        notes = new List<Note>();
        List<float> lines = new List<float>();
        switch(_scoreManager.difficulty)
        {
            //TODO:
            case 0:
                lines = new Note0().GetList();
                break;
            case 1:
                lines = new Note1().GetList();
                break;
            case 2:
                lines = new Note2().GetList();
                break;
            case 3:
                notes = new Beatmap3().GetList();
                break;
            case 4:
                lines = new Note4().GetList();
                break;
        }
        

        /*
        for(int i = 1; i < lines.Count / 3; i++)
        {
            float t = lines[i * 3];
            float x = lines[i * 3 + 1];
            float y = lines[i * 3 + 2];
            if (x - lines[i * 3 - 2] < MIN_DISTANCE && y - lines[i * 3 - 1] < MIN_DISTANCE) continue;
            Note note = new Note(t, x, y);
            notes.Add(note);
        }
        */
    }
}
