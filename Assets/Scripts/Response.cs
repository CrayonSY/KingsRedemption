using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response : MonoBehaviour
{

    private float _time;
    private const float _LIFE_TIME = 0.5f;

    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _LIFE_TIME) Destroy(gameObject);
    }
}
