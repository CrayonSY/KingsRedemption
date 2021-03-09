using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    [SerializeField] private Sprite[] _slides = new Sprite[4];
    [SerializeField] private Image _image;
    [SerializeField] private GameObject prevButton, nextButton;
    [SerializeField] private GameObject difficultySelectImage;
    [SerializeField] private SoundController _soundController;
    private int _slideCount;

    void Start()
    {
        prevButton.SetActive(false);
        nextButton.SetActive(true);
    }

    public void NextButton()
    {
        _soundController.PlaySE(4);
        if (_slideCount < _slides.Length - 1)
        {
            _slideCount++;
            prevButton.SetActive(true);
            _image.sprite = _slides[_slideCount];
        }
        else StartDifficultySelect();
    }

    public void PrevButton()
    {
        _soundController.PlaySE(4);
        if (_slideCount > 0)
        {
            _slideCount--;
            nextButton.SetActive(true);
            _image.sprite = _slides[_slideCount];
        }
        else prevButton.SetActive(false);
    }

    private void StartDifficultySelect()
    {
        difficultySelectImage.SetActive(true);
        gameObject.SetActive(false);
    }

}
