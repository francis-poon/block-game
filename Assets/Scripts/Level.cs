using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public readonly int[,] level;
    public readonly Vector2 startingPos;
    public int bestScore { get; private set; }
    public Level(int[,] level, Vector2 startingLevel)
    {
        this.level = level;
        this.startingPos = startingLevel;
        bestScore = 0;
    }

    public bool AddScore(int score)
    {
        bool isNewBestScore = bestScore == 0 || score < bestScore;
        if (isNewBestScore)
        {
            bestScore = score;
        }
        return isNewBestScore;
    }
}
