using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float time;
    public int tileCount, kingTileCount;
    public readonly float TIME_OFFSET_FOR_MUSIC_STARTS = 2f;

    [SerializeField] private MainController _mainController;
    [SerializeField] private NoteLoading _noteLoading;
    [SerializeField] private GameObject tilePrefab, opponentTilePrefab, tileParent;

    [SerializeField] private Sprite[] pieceImages = new Sprite[16];
    //[SerializeField] private Text text;

    private const float LIFE_TIME = 1.5f;
    private Note _note;
    private int _length;
    //TODO:
    private int[] _bpms = { 0, 0, 0, 173, 0 };
    private float[] _offsets = { 0, 0, 0, -2.27f, 0 };
    //private GameObject[] _tiles = new GameObject[4];

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (!_mainController.isPlayingGame) return;
        time += Time.deltaTime;

        if (tileCount >= _noteLoading.notes.Count-1) return;

        _note = _noteLoading.notes[tileCount];
        _length = _noteLoading.notes.Count;
        
        // Display 1sec before the perfect timing. 
        if (TIME_OFFSET_FOR_MUSIC_STARTS + _offsets[_mainController.GetDifficulty()] + _note.time * 60/_bpms[_mainController.GetDifficulty()] < time -1f)
        {
            AddNewTile(_note);
            if (tileCount < _length - 1)
            {
                tileCount++;
                if (_note.piece == 0) kingTileCount++;
            }
        }
    }

    public void ResetTimer()
    {
        time = 0;
        
        //for (int i = 0; i < _tiles.Length; i++) _tiles[i] = null;
    }

    private void AddNewTile(Note note)
    {
        // If there is the same kind of piece in the screen.
        //if(_tiles[note.piece] != null) _tiles[note.piece].GetComponent<TileButton>().Fail(note.piece);
        //Debug.Log(tileCount+" "+note.time + " " + note.x + " " + note.y);
        
        Tile tile = note.piece == 0 ? new Tile(tileCount, note.piece, kingTileCount) : new Tile(tileCount, note.piece);

        GameObject prefab = note.piece == 0 ? tilePrefab : opponentTilePrefab;
        GameObject tileUI = Instantiate(prefab, tileParent.transform);

        Vector3 pos = new GridManager().GetPosition(note.x, note.y);
        tileUI.GetComponent<RectTransform>().localPosition = pos;
        tileUI.GetComponent<TileButton>().tile = tile;

        //_tiles[note.piece] = tileUI;
    }
}
