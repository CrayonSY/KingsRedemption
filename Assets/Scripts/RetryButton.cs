using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    [SerializeField] private MusicController _musicController;
    [SerializeField] private Canvas failedCanvas, menuCanvas;
    public void OnClick()
    {
        menuCanvas.enabled = true;
        failedCanvas.enabled = false;
        _musicController.Play(5);
    }
}
