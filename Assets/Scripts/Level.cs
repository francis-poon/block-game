using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public readonly int[,] level;
    public readonly Vector2 startingPos;
    public readonly string rewardFileName;

    public Level(int[,] level, Vector2 startingLevel, string rewardFileName)
    {
        this.level = level;
        this.startingPos = startingLevel;
        this.rewardFileName = rewardFileName;
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
