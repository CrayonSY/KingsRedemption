using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    bool isTopScreen;
    [SerializeField] GameObject topImage;
    [SerializeField] GameObject slideShow;

    void Start()
    {
        isTopScreen = true;
        topImage.SetActive(true);
    }
    
    void Update()
    {
        GoToSlideShow();
    }
    
    private void GoToSlideShow()
    {
        if (!isTopScreen) return;
        if (!Input.GetMouseButtonDown(0)) return;
        topImage.SetActive(false);
        slideShow.SetActive(true);
        isTopScreen = false;
    }

}
