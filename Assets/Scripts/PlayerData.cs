using System.Collections.Generic;
using System.Xml;

public class PlayerData
{
    public int unlockedLevel;
    private Dictionary<UniqueId, int> bestScores;

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

    public int GetBestScore(UniqueId levelId)
    {
        return bestScores.ContainsKey(levelId) ? bestScores[levelId] : 0;
    }

    public bool Load()
    {
        return false;
    }

    public bool Save()
    {

        return false;
    }
}
