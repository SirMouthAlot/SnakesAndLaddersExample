using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 _position;
    Transform trans;

    int _currentTile = 1;

    bool _thisPlayersTurn;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();

        _position = trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = _position;
    }

    public Vector2 GetPosition()
    {
        return _position;
    }

    public void SetPosition(Vector2 pos)
    {
        _position = pos;
    }

    public bool GetThisPlayersTurn()
    {
        return _thisPlayersTurn;
    }

    public void SetThisPlayerTurn(bool thisTurn)
    {
        _thisPlayersTurn = thisTurn;
    }

    public int GetCurrentTile()
    {
        return _currentTile;
    }

    public void SetCurrentTile(int currentTile)
    {
        _currentTile = currentTile;
    }
}
