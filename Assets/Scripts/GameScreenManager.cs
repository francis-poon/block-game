using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScreenManager : MonoBehaviour
{
    [Header("In Game Display")]
    [SerializeField]
    private GameObject levelDisplay;
    [SerializeField]
    private GameObject levelText;
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    private GameObject bestScoreText;
    

    [Header("Cleared Level Display")]
    [SerializeField]
    private GameObject clearedLevelDisplay;
    [SerializeField]
    private GameObject clearedScoreText;
    [SerializeField]
    private GameObject clearedDisplayTitle;
    [SerializeField]
    private GameObject nextLevelButton;
    [SerializeField]
    private GameObject rewardDisplay;

    [Header("Paused Display")]
    [SerializeField]
    private GameObject pausedDisplay;

    private bool updateScore;
    private bool paused;
    private GameObject[] unlockables;

    private void Awake()
    {
        GameManager.onAfterStateChanged += OnStateChanged;
        updateScore = false;
        paused = false;
        unlockables = new GameObject[GameData.levels.GetLength(0)];
    }

    private void OnDestroy()
    {
        GameManager.onAfterStateChanged -= OnStateChanged;
    }
    private void Start()
    {
        bestScoreText.GetComponent<TextMeshProUGUI>().text = $"{GameData.levels[GameManager.instance.currentLevel].bestScore}";
        for (int c = 0; c < GameData.levels.GetLength(0); c ++)
        {
            GameObject reward = new GameObject();
            reward.transform.SetParent(rewardDisplay.transform);
            reward.transform.localEulerAngles = Vector3.zero;
            reward.transform.localScale = Vector3.one;
            reward.transform.localPosition = Vector3.zero;
            reward.AddComponent<SpriteRenderer>();
            reward.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(GameData.rewards[c]);
            reward.GetComponent<SpriteRenderer>().sortingLayerName = GameData.GUI_LAYER; 
            reward.GetComponent<SpriteRenderer>().sortingOrder = 1;
            unlockables[c] = reward;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (GameManager.instance.state == GameState.Playing || GameManager.instance.state == GameState.Paused))
        {
            paused = !paused;
            if (paused)
            {
                GameManager.instance.ChangeState(GameState.Paused);
            }
            else
            {
                GameManager.instance.ChangeState(GameState.Playing);
            }
        }

        if (updateScore)
        {
            scoreText.GetComponent<TextMeshProUGUI>().text = $"{GameManager.instance.score}";
        }
    }

    private void OnStateChanged(GameState newState)
    {
        updateScore = false;
        switch (newState)
        {
            case GameState.Playing:
                Debug.Log("Game Screen received playing state");
                levelDisplay.SetActive(true);
                clearedLevelDisplay.SetActive(false);
                pausedDisplay.SetActive(false);
                levelText.GetComponent<TextMeshProUGUI>().text = $"Level {GameManager.instance.currentLevel + 1}";
                updateScore = true;
                bestScoreText.GetComponent<TextMeshProUGUI>().text = $"{GameData.levels[GameManager.instance.currentLevel].bestScore}";
                break;
            case GameState.Paused:
                levelDisplay.SetActive(true);
                clearedLevelDisplay.SetActive(false);
                pausedDisplay.SetActive(true);
                break;
            case GameState.ClearedLevel:
                clearedDisplayTitle.GetComponent<TextMeshProUGUI>().text = GameManager.instance.HasNextLevel() ? "CLEARED" : "COMPLETE";
                clearedScoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {GameManager.instance.score}";
                levelDisplay.SetActive(false);
                clearedLevelDisplay.SetActive(true);
                pausedDisplay.SetActive(false);
                nextLevelButton.GetComponent<Button>().interactable = GameManager.instance.HasNextLevel();
                for (int c = 0; c < GameData.levels.GetLength(0); c ++)
                {
                    unlockables[c].SetActive(c + 1 <= GameData.unlockedLevel);
                }
                break;
        }
    }

    //===========================================================================================
    //===== BUTTON FUNCTIONS ====================================================================
    //===========================================================================================

    public void GoToNextLevel()
    {
        GameManager.instance.LoadLevel();
    }

    public void ResetLevel()
    {
        paused = false;
        GameManager.instance.LoadLevel();
    }

    public void Retry()
    {
        paused = false;
        GameManager.instance.ResetLevel();
    }

    public void GoToLevelSelect()
    {
        GameData.homeScreenDisplay = "levelSelect";
        SceneManager.LoadScene("HomeScene");
    }

    public void GoHome()
    {
        GameData.homeScreenDisplay = "home";
        SceneManager.LoadScene("HomeScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        paused = false;
        GameManager.instance.ChangeState(GameState.Playing);
    }
}
