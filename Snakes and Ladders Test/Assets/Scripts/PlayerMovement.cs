using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Inspector values
    [SerializeField] private List<Player> players;
    public float _speed;

    [SerializeField] private Board _board = new Board();
    [SerializeField] private Text _text;

    //Positional values
    Vector2 _currentPos;
    Vector2 _nextPos;

    //Time variables
    float _totalTime;
    float _t;

    //Game turn data
    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    //Current turn information
    int _currentPlayer = 0;
    int _tileMovementAmount;

    //Our die
    Dice _dice = new Dice();


    // Start is called before the first frame update
    void Start()
    {

        _board.InitTilePositions();

        _text.text = "Press 'Space' to roll the dice";
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameIsOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("SnakesAndLadders");


        if ((players[0].GetCurrentTile() == 100 || players[1].GetCurrentTile() == 100) && !_isMoving)
        {
            _gameIsOver = true;
            _text.text = $"Game Over! Player {_currentPlayer + 1} Wins! Press 'Space' to play again!";
        }

        if (!_gameIsOver)
        {
            _currentPos = players[_currentPlayer].GetPosition();

            if (_currentPlayer == 0)
                _text.color = Color.magenta;
            if (_currentPlayer == 1)
                _text.color = Color.yellow;

            if (Input.GetKeyDown(KeyCode.Space) && _tileMovementAmount == 0)
            {
                _tileMovementAmount = _dice.RollDice();
                _text.text = "You Rolled a " + _tileMovementAmount.ToString();
                _turnStarted = true;
            }

            if (_tileMovementAmount > 0 && !_isMoving)
                MoveOneTile();

            if (_isMoving)
                UpdatePosition();

            for (int i = 0; i < _board.GetSnakes().Count; i++)
            {
                if (_tileMovementAmount == 0 && players[_currentPlayer].GetCurrentTile() == _board.GetSnakes()[i].GetHeadTile())
                {
                    _tileMovementAmount = 1;

                    //Move down the snake
                    MoveDownSnake(i);
                }
            }

            for (int i = 0; i < _board.GetLadders().Count; i++)
            {
                if (_tileMovementAmount == 0 && players[_currentPlayer].GetCurrentTile() == _board.GetLadders()[i].GetBottomTile())
                {
                    _tileMovementAmount = 1;

                    //Climb to the top of the ladder
                    ClimbLadder(i);
                }
            }

            if (_tileMovementAmount == 0 && !_isMoving)
            {
                _text.text = "Press 'Space' to roll the dice";

                if (_turnStarted)
                {
                    _turnStarted = false;

                    if (_currentPlayer == 0)
                        _currentPlayer = 1;
                    else if (_currentPlayer == 1)
                        _currentPlayer = 0;
                }
            }
        }
    }
    void UpdatePosition()
    {
        _t += Time.deltaTime / _totalTime;

        if (_t < 0f)
            _t = 0f;

        if (_t >= 1f || _nextPos == _currentPos)
        {
            _isMoving = false;
            _tileMovementAmount--;
            _t = 0;
        }

        players[_currentPlayer].SetPosition(Vector2.Lerp(_currentPos, _nextPos, _t));
    }

    void MoveOneTile()
    {
        _nextPos = _board.GetTilePositions()[players[_currentPlayer].GetCurrentTile()];

        _totalTime = (_nextPos - _currentPos / _speed).magnitude;

        _isMoving = true;

        players[_currentPlayer].SetCurrentTile(players[_currentPlayer].GetCurrentTile() + 1);
    }

    void MoveDownSnake(int slot)
    {
        players[_currentPlayer].SetCurrentTile(_board.GetSnakes()[slot].GetTailTile()-1);
    }

    void ClimbLadder(int slot)
    {
        players[_currentPlayer].SetCurrentTile(_board.GetLadders()[slot].GetTopTile()-1);
    }
}
