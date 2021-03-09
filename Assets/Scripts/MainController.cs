using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public bool isPlayingGame;
    public int totalMisstakes;
    public bool[] clears = new bool[5];

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject tileParent;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Canvas gameCanvas, victoryCanvas, failedCanvas;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private MusicController _musicController;
    [SerializeField] private TimeController _timeController;
    //[SerializeField] private LogCollector _logController;
    [SerializeField] private NoteLoading _noteLoading;
    [SerializeField] private SoundController _soundController;

    private int[] _mistakesAllowed = { 0, 0, 0, 60, 0 };

    private float _time;
    void Update()
    {
        _time += Time.deltaTime;
        RayForTiles();
        // Win
        if (!_musicController.isPlaying && isPlayingGame) FinishGame();
        // Lose
        if (isPlayingGame && totalMisstakes == _mistakesAllowed[_scoreManager.difficulty]) GameOver();
    }
    
    public void Init()
    {
        DestroyAllTiles();
        _scoreManager.Init();
        _timeController.tileCount = 0;
        totalMisstakes = 0;
        if (GameObject.FindWithTag("KingImage") != null) Destroy(GameObject.FindWithTag("KingImage"));
        for(int i = 1; i <=3; i++)
            if (GameObject.FindWithTag("OpponentImage" + i)) Destroy(GameObject.FindWithTag("OpponentImage" + i));
    }

    private void SetProgressBar()
    {
        GameObject progressBar = GameObject.FindWithTag("ProgressBar");
        progressBar.GetComponent<ProgressBar>().Init();
        int totalNotes = new ProgressBar().totalKingNotes[_scoreManager.difficulty];
        Color color = Color.red;
        switch (_scoreManager.difficulty)
        {
            case 0:
                color = Color.green;
                break;
            case 1:
                color = Color.blue;
                break;
            case 2:
                color = Color.yellow;
                break;
            case 3:
                color = new Color(1, 0.5f, 0);
                break;
            case 4:
                color = Color.red;
                break;
        }
        progressBar.transform.GetChild(0).GetComponent<Image>().color = color;
        float height = progressBar.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.y;
        float y = height / 2 - height * ((float)_mistakesAllowed[_scoreManager.difficulty] / totalNotes);
        progressBar.transform.GetChild(2).GetComponent<RectTransform>().localPosition = new Vector3(0, y, 0);
    }
    private void DestroyAllTiles()
    {
        for (int i = tileParent.transform.childCount; i > 0; i--) Destroy(tileParent.transform.GetChild(i - 1).gameObject);
    }
    

    public void StartGame()
    {
        isPlayingGame = true;
        _timeController.ResetTimer();
        _musicController.Play(_scoreManager.difficulty);
        //_logController.Init();
        _noteLoading.LoadNotes();
        SetProgressBar();

        Debug.Log("Game Start");
        _time = 0f;
    }

    public void GetTheOffset()
    {
        Debug.Log(_time);
    }

    // win
    public void FinishGame()
    {
        isPlayingGame = false;
        victoryCanvas.enabled = true;
        gameCanvas.enabled = false;
        victoryCanvas.GetComponent<VictoryImageController>().ChangeImage(_scoreManager.difficulty);
        clears[_scoreManager.difficulty] = true;
        _soundController.PlaySE(5);
    }
    
    public void GameOver()
    {
        isPlayingGame = false;
        DestroyAllTiles();
        _musicController.Stop();
        failedCanvas.enabled = true;
        gameCanvas.enabled = false;
        trailRenderer.enabled = false;
        //_scoreManager.DisplayHighScore();
    }
    
    public Transform GetGameCanvas()
    {
        return gameCanvas.transform;
    }

    public int GetDifficulty()
    {
        return _scoreManager.difficulty;
    }

    private void RayForTiles()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach (RaycastHit2D hit in Physics2D.RaycastAll(worldPoint, Vector2.zero))
        {
            if (hit)
            {
                Debug.Log("hit");
                if (hit.collider.gameObject.CompareTag("Tile"))
                    hit.collider.GetComponent<TileButton>().OnPointerEnter();
            }
        }
    }

}
