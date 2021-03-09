using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    public Tile tile;
    private MainController _mainController;
    private TimeController _timeController;
    private ScoreManager _scoreManager;
    private GameObject _scripts;
    private ProgressBar _progressBar;
    private float _time;
    private const float LIFE_TIME = 1.5f;
    private Vector3 _pos, _size;

    [SerializeField] private GameObject responsePrefab;
    [SerializeField] private GameObject kingPrefab;

    void Start()
    {
        _time = LIFE_TIME;
        _scripts = GameObject.FindWithTag("Scripts");
        _progressBar = GameObject.FindWithTag("ProgressBar").GetComponent<ProgressBar>();
        _mainController = _scripts.GetComponent<MainController>();
        if(tile.playerKind == 0)
        transform.GetChild(0).gameObject.GetComponent<Text>().text = (tile.kingId +1).ToString();
        _pos = GetComponent<RectTransform>().localPosition;
        _size = GetComponent<RectTransform>().sizeDelta;
    }

    void Update()
    {
        _time -= Time.deltaTime;
        //OnPointerEnter();
        if (tile.playerKind == 0) // if king
        {
            if (_time < 0) Fail(0);
            return;
        }
        
        if (_time < 0.5f) MoveOpponentImage();
    }

    public void OnPointerEnter()
    {
        if (tile.playerKind != 0) return;
        if (!_mainController.isPlayingGame) return;

        //var mouse = Input.mousePosition;
        //mouse.x -= Screen.width / 2;
        //mouse.y -= Screen.height / 2;
        //if (Math.Pow(_pos.x - mouse.x, 2) + Math.Pow(_pos.y - mouse.y, 2) > Math.Pow(_size.x/2, 2)) return;

        _scoreManager = _scripts.GetComponent<ScoreManager>();
        float size = GetComponentInChildren<Shrink>().size;
        float accuracy = Math.Abs(size - 1);
        //Success(2);
        if (accuracy < 0.3) Success(2);
        else Success(1);
    }

    public void Fail(int tileKind)
    {
        if (tileKind == 0)
        {
            _progressBar.Bad();
            Respond(0);
            _mainController.totalMisstakes++;
        }
        Destroy(gameObject);
    }


    private void Success(int id)
    {
        //_mainController.tileSetting[tile.x, tile.y] = -1;
        //_timeController.ResetTimer();
        _progressBar.OK();
        _scoreManager.RaiseScore(100*id);
        Respond(id);
        
#if UNITY_EDITOR
        _timeController = _scripts.GetComponent<TimeController>();
        Log();
#endif
        Destroy(gameObject);
    }
    
    private void Respond(int response)
    {
        MoveKingImage();
        GameObject obj = Instantiate(responsePrefab, _mainController.GetGameCanvas());
        obj.transform.position = transform.position;
        Text txt = obj.GetComponent<Text>();
        Color color = default(Color);
        string colorCode = "";
        switch (response)
        {
            case 0:
                txt.text = "Miss";
                colorCode = "#0E71CC";
                break;
            case 1:
                txt.text = "Good";
                colorCode = "#FF9A00";
                break;
            case 2:
                txt.text = "Great";
                colorCode = "#FF00CF";
                break;
        }
        if (ColorUtility.TryParseHtmlString(colorCode, out color))
        {
            txt.color = color;
        }
    }

    private void MoveKingImage()
    {
        GameObject kingImage = GameObject.FindWithTag("KingImage") == null ?
            Instantiate(kingPrefab, _mainController.GetGameCanvas()) :
            GameObject.FindWithTag("KingImage");
        kingImage.GetComponent<RectTransform>().position = transform.position;
    }

    private void MoveOpponentImage()
    {

        _mainController.GetTheOffset();
        GameObject obj;
        int playerKind = tile.playerKind;
        if(GameObject.FindWithTag("OpponentImage"+playerKind) == null)
        {
            obj = Instantiate(kingPrefab, _mainController.GetGameCanvas());
            obj.tag = transform.tag = "OpponentImage"+playerKind;
        }
        else
        {
            obj = GameObject.FindWithTag("OpponentImage" + playerKind);
        }
        obj.GetComponent<RectTransform>().position = transform.position;
        Destroy(gameObject);
    }

    private void Log()
    {
        string log = (_scoreManager.difficulty + 1) + "-" + (tile.id + 1) + ": t=" + _timeController.time + ", x=" + tile.x + ", y=" + tile.y + "\n";
        string file_path = System.IO.Path.Combine(@".\log.txt");
        if (!System.IO.File.Exists(file_path))
        {
            return;
        }
        // ファイルからデータを読み取る
        string file_data = string.Empty;    // ファイルのデータ
        using (StreamReader sr = new System.IO.StreamReader(file_path))   // UTF-8のテキスト用
        {
            file_data = sr.ReadToEnd(); // ファイルのデータを「すべて」取得する
        }
        log = file_data + log;
        // ファイルへテキストデータを書き込む
        using (StreamWriter sw = new StreamWriter(file_path))   // UTF-8のテキスト用
        {
            sw.Write(log); // ファイルへテキストデータを出力する
        }
    }

    

}
