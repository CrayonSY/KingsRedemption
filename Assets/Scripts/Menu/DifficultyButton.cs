using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private Canvas gameCanvas, menuCanvas;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private MainController _mainController;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private Sprite _bgImage;
    [SerializeField] private SoundController _soundController;

    private Text t;
    private void Start()
    {
        t = GetComponentInChildren<Text>();
    }

    void Update()
    {
        int difficulty = gameObject.transform.GetSiblingIndex();
        if (_mainController.clears[difficulty]) t.enabled = true;
    }

    public void OnClick()
    {
        _soundController.PlaySE(4);
        trailRenderer.enabled = true;
        gameCanvas.enabled = true;
        scoreManager.difficulty = gameObject.transform.GetSiblingIndex();
        GameObject.FindWithTag("GameBackground").GetComponent<Image>().sprite = _bgImage;
        _mainController.Init();
        menuCanvas.enabled = false;
        _mainController.StartGame();
        
    }

}
