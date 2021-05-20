using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    Vector2 currentPos;
    Vector2 nextPos;

    float speed = 0.4f;
    float totalTime;
    float t;

    bool isMoving;
    bool gameIsOver;
    bool turnStarted;

    int currentPlayer = 0;
    int tileMovementAmount;

    Dice dice = new Dice();
    Board board = new Board();
    [SerializeField] private Text text;

    [SerializeField] private List<Player> players;


    // Start is called before the first frame update
    void Start()
    {

        board.InitTilePositions();

        text.text = "Press 'Space' to roll the dice";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("SnakesAndLadders");


        if ((players[0].GetCurrentTile() == 100 || players[1].GetCurrentTile() == 100) && !isMoving)
        {
            gameIsOver = true;
            text.text = $"Game Over! Player {currentPlayer + 1} Wins! Press 'Space' to play again!";
        }

        if (!gameIsOver)
        {
            currentPos = players[currentPlayer].GetPosition();

            if (currentPlayer == 0)
                text.color = Color.magenta;
            if (currentPlayer == 1)
                text.color = Color.yellow;

            if (Input.GetKeyDown(KeyCode.Space) && tileMovementAmount == 0)
            {
                tileMovementAmount = dice.RollDice();
                text.text = "You Rolled a " + tileMovementAmount.ToString();
                turnStarted = true;
            }

            if (tileMovementAmount > 0 && !isMoving)
                MoveOneTile();

            if (isMoving)
                UpdatePosition();

            for (int i = 0; i < board.GetSnakes().Length; i++)
            {
                if (tileMovementAmount == 0 && players[currentPlayer].GetCurrentTile() == board.GetSnakes()[i].GetHeadTile())
                {
                    tileMovementAmount = 1;

                    //Move down the snake
                    MoveDownSnake(i);
                }
            }

            for (int i = 0; i < board.GetLadders().Length; i++)
            {
                if (tileMovementAmount == 0 && players[currentPlayer].GetCurrentTile() == board.GetLadders()[i].GetBottomTile())
                {
                    tileMovementAmount = 1;

                    //Climb to the top of the ladder
                    ClimbLadder(i);
                }
            }

            if (tileMovementAmount == 0 && !isMoving)
            {
                text.text = "Press 'Space' to roll the dice";

                if (turnStarted)
                {
                    turnStarted = false;

                    if (currentPlayer == 0)
                        currentPlayer = 1;
                    else if (currentPlayer == 1)
                        currentPlayer = 0;
                }
            }
        }
    }
    void UpdatePosition()
    {
        t += Time.deltaTime / totalTime;

        if (t < 0f)
            t = 0f;

        if (t >= 1f || nextPos == currentPos)
        {
            isMoving = false;
            tileMovementAmount--;
            t = 0;
        }

        players[currentPlayer].SetPosition(Vector2.Lerp(currentPos, nextPos, t));
    }

    void MoveOneTile()
    {
        nextPos = board.GetTilePositions()[players[currentPlayer].GetCurrentTile()];

        totalTime = (nextPos - currentPos / speed).magnitude;

        isMoving = true;

        players[currentPlayer].SetCurrentTile(players[currentPlayer].GetCurrentTile() + 1);
    }

    void MoveDownSnake(int slot)
    {
        nextPos = board.GetSnakes()[slot].GetTailPosition();

        totalTime = (nextPos - currentPos / speed).magnitude;

        isMoving = true;

        //currentTile = board.GetSnakes()[slot].GetTailTile();

        players[currentPlayer].SetCurrentTile(board.GetSnakes()[slot].GetTailTile());
    }

    void ClimbLadder(int slot)
    {
        nextPos = board.GetLadders()[slot].GetTopPosition();

        totalTime = (nextPos - currentPos / speed).magnitude;

        isMoving = true;

        //currentTile = board.GetLadders()[slot].GetTopTile();

        players[currentPlayer].SetCurrentTile(board.GetLadders()[slot].GetTopTile());
    }
}
