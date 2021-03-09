using UnityEngine;

public class GridManager
{
    private const int _GRID_NUM = 8;

    // x_index and y_index must be 0~7;
    public Vector3 GetPosition(int x_index, int y_index)
    {
        if (x_index < 0 || x_index >= _GRID_NUM || y_index < 0 || y_index >= _GRID_NUM) return Vector3.zero;
        //float _width = Screen.width *0.9f; // 1024*0.8
        //float _height = Screen.height * 0.8f; // 768*0.8
        float _width = 550f;
        float _height = 550f;
        float x = _width / 16 + _width / _GRID_NUM * x_index -_width/2;
        float y = _height / 16 + _height / _GRID_NUM * y_index -_height/2;

        return new Vector3(x, y, 0);
    }
}
