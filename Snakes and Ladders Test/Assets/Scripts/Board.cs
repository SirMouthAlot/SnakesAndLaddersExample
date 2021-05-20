using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{

    Snake[] _snakes = { new Snake(36, 5, new Vector2(-0.5f, -4.5f)), new Snake(49, 7, new Vector2(1.5f, -4.5f)),
                        new Snake(56, 8, new Vector2(2.5f, -4.5f)), new Snake(82, 20, new Vector2(-4.5f, -3.5f)),
                        new Snake(87, 66, new Vector2(0.5f, 1.5f)), new Snake(95, 38, new Vector2(-2.5f, -1.5f)) };

    Ladder[] _ladders = { new Ladder(35, 5, new Vector2(0.5f, -1.5f)), new Ladder(51, 9, new Vector2(4.5f, 0.5f)),
                          new Ladder(42, 23, new Vector2(-3.5f, -0.5f)), new Ladder(86, 48, new Vector2(0.5f, 3.5f)),
                          new Ladder(83, 62, new Vector2(-2.5f, 3.5f)), new Ladder(91, 69, new Vector2(4.5f, 4.5f)) };

    Vector2[] _tilePositions = new Vector2[100];

    public Snake[] GetSnakes()
    {
        return _snakes;
    }

    public Ladder[]  GetLadders()
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

        _tilePositions[0] = new Vector2(-4.5f, -4.5f);

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
