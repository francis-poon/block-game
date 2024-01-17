using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public readonly int[,] level;
    public readonly Vector2 startingPos;
    public int highScore { get; private set; }
    public Level(int[,] level, Vector2 startingLevel)
    {
        this.level = level;
        this.startingPos = startingLevel;
        highScore = 0;
    }

    public bool AddScore(int score)
    {
        bool isNewHighScore = score > highScore;
        if (isNewHighScore)
        {
            highScore = score;
        }
        return isNewHighScore;
    }
}
