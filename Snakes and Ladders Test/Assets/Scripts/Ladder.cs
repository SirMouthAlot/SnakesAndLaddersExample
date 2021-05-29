using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Ladder
{
    [SerializeField] private int _topTile;
    [SerializeField] private int _bottomTile;


    public Ladder(int topTile, int bottomTile)
    {
        _topTile = topTile;
        _bottomTile = bottomTile;
    }

    public int GetTopTile()
    {
        return _topTile;
    }

    public int GetBottomTile()
    {
        return _bottomTile;
    }
}
