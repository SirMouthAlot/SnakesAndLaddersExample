using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    public int RollDice()
    {
        float diceRoll = Random.Range(0, 6);

        return (int)diceRoll + 1;
    }
}
