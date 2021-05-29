using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Snake
{
    [SerializeField] private int _headTile;
    [SerializeField] private int _tailTile;


    public Snake(int headTile, int tailTile)
    {
        _headTile = headTile;
        _tailTile = tailTile;
    }

    public int GetHeadTile()
    {
        return _headTile;
    }

    public int GetTailTile()
    {
        return _tailTile;
    }
}
