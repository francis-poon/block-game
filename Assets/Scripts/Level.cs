using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level
{
    public readonly int[,] level;
    public readonly Vector2 startingPos;
    public readonly string rewardFileName;
    public readonly UniqueId id;

    public Level(int[,] level, Vector2 startingLevel, string rewardFileName, UniqueId id)
    {
        this.level = level;
        this.startingPos = startingLevel;
        this.rewardFileName = rewardFileName;
        this.id = id;
    }

    
}
