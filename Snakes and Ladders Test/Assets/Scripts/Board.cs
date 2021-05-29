using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Board
{
    [SerializeField] private Transform _initialTransform;
    [SerializeField] private List<Snake> _snakes;
    [SerializeField] private List<Ladder> _ladders;

    Vector2[] _tilePositions = new Vector2[100];

    public List<Snake> GetSnakes()
    {
        return _snakes;
    }

    public List<Ladder>  GetLadders()
    {
        return _ladders;
    }

    public Vector2[] GetTilePositions()
    {
        return _tilePositions;
    }

    public void InitTilePositions()
    {
        bool reverse = false;

        _tilePositions[0] = new Vector2(_initialTransform.position.x, _initialTransform.position.y);

        for (int i = 1; i < 100; i++)
        {
            if (i % 10 == 0)
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(0f, 1f);
            else if (!reverse)
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(1f, 0f);
            else if (reverse)
                _tilePositions[i] = _tilePositions[i - 1] + new Vector2(-1f, 0f);

            if ((i + 1) % 10 == 0)
                reverse = !reverse;
        }
    }

}
