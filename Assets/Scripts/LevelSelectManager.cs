using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject levelSelectButton;

    [Header("Attributes")]
    [SerializeField]
    private GameObject levelSelectGrid;
    [SerializeField]
    private GameObject rewardDisplay;

    private GameObject[] levelSelectButtons;

    private void Awake()
    {
        levelSelectButtons = new GameObject[GameData.levels.GetLength(0)];
    }

    private void Start()
    {
        for (int c = 0; c < GameData.levels.GetLength(0); c++)
        {
            levelSelectButtons[c] = Instantiate(levelSelectButton, levelSelectGrid.transform);
            levelSelectButtons[c].GetComponentInChildren<TextMeshProUGUI>().text = $"{c + 1}";
            int levelIndex = c;
            levelSelectButtons[c].GetComponent<Button>().onClick.AddListener(() => SelectLevel(levelIndex));
            levelSelectButtons[c].GetComponent<Button>().onClick.AddListener(StartGame);
            levelSelectButtons[c].GetComponent<Button>().interactable = c <= GameData.unlockedLevel;
            GameObject reward = new GameObject();
            reward.transform.SetParent(rewardDisplay.transform);
            reward.transform.localEulerAngles = Vector3.zero;
            reward.transform.localScale = Vector3.one;
            reward.transform.localPosition = Vector3.zero;
            reward.AddComponent<SpriteRenderer>();
            reward.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(GameData.rewards[c]);
            reward.GetComponent<SpriteRenderer>().sortingOrder = 1;
            reward.SetActive(c + 1 <= GameData.unlockedLevel);
        }
        
    }

    public void SelectLevel(int level)
    {
        Debug.Log($"Selecting level {level}");
        GameData.selectedLevel = level;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
