using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceGif : MonoBehaviour
{
     private ScoreManager _scoreManager;
    [SerializeField] private Sprite[] gif0, gif1, gif2, gif3, gif4;

    private float _time;
    private float _lastChangedTime;
    private Sprite[] _sprites;
    private int index;

    private const float _SPEED = 0.1f;

    void Start()
    {
        _scoreManager = GameObject.FindWithTag("Scripts").GetComponent<ScoreManager>();
        switch (_scoreManager.difficulty)
        {
            case 0:
                _sprites = gif0;
                break;
            case 1:
                _sprites = gif1;
                break;
            case 2:
                _sprites = gif2;
                break;
            case 3:
                _sprites = gif3;
                break;
            case 4:
                _sprites = gif4;
                break;
        }
        GetComponent<Image>().sprite = _sprites[0];
    }
    
    void Update()
    {
        _time += Time.deltaTime;
        if (_lastChangedTime + _SPEED > _time ) return;
        _lastChangedTime = _time;
        index++;
        if (index >= _sprites.Length) index = 0;
        GetComponent<Image>().sprite = _sprites[index];
    }
}
