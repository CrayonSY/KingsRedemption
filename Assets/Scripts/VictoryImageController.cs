using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryImageController : MonoBehaviour
{

    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprites = new Sprite[5];

    public void ChangeImage(int index)
    {
        _image.sprite = _sprites[index];
    }
    
}
