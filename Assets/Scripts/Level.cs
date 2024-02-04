using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Level
{
    public int[][] level;
    public Vector2 startingPos;
    public string rewardFileName;
    [XmlElement("id")]
    public string idString { get => id.ToString(); set => id = new UniqueId(value); }

    [XmlIgnore]
    public UniqueId id;

    public Level()
    {
        
    }

    public Level(int[][] level, Vector2 startingPos, string rewardFileName, UniqueId id)
    {
        this.level = level;
        this.startingPos = startingPos;
        this.rewardFileName = rewardFileName;
        this.id = id;
    }

    
}
