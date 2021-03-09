using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    
    void Update()
    {
        // マウス位置座標を格納する
        Vector3 position = Input.mousePosition;
        // Z軸の修正
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標と追従させたいオブジェクトの距離を測り、それを割る速度したものを現在位置に加算していく
        gameObject.transform.position = screenToWorldPointPosition;
    }
}
