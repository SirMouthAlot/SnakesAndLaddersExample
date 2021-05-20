using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder
{
    int _topTile;
    int _bottomTile;
    Vector2 _topPos;


    public Ladder(int topTile, int bottomTile, Vector2 topPos)
    {
        _topTile = topTile;
        _bottomTile = bottomTile;
        _topPos = topPos;
    }

    public int GetTopTile()
    {
        return _topTile;
    }

    public int GetBottomTile()
    {
        return _bottomTile;
    }

    public Vector2 GetTopPosition()
    {
        return _topPos;
    }
}
