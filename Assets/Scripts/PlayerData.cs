using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Dictionary<UniqueId, int> bestScores;
    public int unlockedLevel;

    public PlayerData()
    {
        bestScores = new Dictionary<UniqueId, int>();
        unlockedLevel = 0;
    }

    public PlayerData(Dictionary<UniqueId, int> bestScores, int unlockedLevel)
    {
        this.bestScores = bestScores;
        this.unlockedLevel = unlockedLevel;
    }

    public bool AddScore(UniqueId levelId, int score)
    {
        if (!bestScores.ContainsKey(levelId) || score < bestScores[levelId])
        {
            bestScores[levelId] = score;
            return true;
        }
        return false;
    }
}
