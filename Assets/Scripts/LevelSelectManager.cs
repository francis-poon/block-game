using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private GameObject[] levelSelectButtons;

    private void Awake()
    {
        for (int c = 0; c < levelSelectButtons.Length; c++)
        {
            levelSelectButtons[c].GetComponent<Button>().interactable = c <= GameData.unlockedLevel;
        }
    }

    public void SelectLevel(int level)
    {
        GameData.selectedLevel = level;
    }
}
