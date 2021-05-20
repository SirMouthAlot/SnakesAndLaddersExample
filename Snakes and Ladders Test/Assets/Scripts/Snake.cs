using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake
{
    int _headTile;
    int _tailTile;
    Vector2 _tailPos;


    public Snake(int headTile, int tailTile, Vector2 tailPos)
    {
        _headTile = headTile;
        _tailTile = tailTile;
        _tailPos = tailPos;
    }

    public int GetHeadTile()
    {
        return _headTile;
    }

    public int GetTailTile()
    {
        return _tailTile;
    }

    public Vector2 GetTailPosition()
    {
        return _tailPos;
    }
}
