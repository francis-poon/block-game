using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScreenManager : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private GameObject levelText;
    [SerializeField]
    private GameObject scoreText;

    private bool updateScore;

    private void Awake()
    {
        GameManager.onAfterStateChanged += OnStateChanged;
        updateScore = false;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (!updateScore)
        {
            return;
        }

        scoreText.GetComponent<TextMeshProUGUI>().text = $"{GameManager.instance.score}";
    }

    private void OnStateChanged(GameState newState)
    {
        updateScore = false;
        if (newState == GameState.LoadingLevel)
        {
            levelText.GetComponent<TextMeshProUGUI>().text = $"Level {GameManager.instance.unlockedLevel + 1}";
        }
        else if (newState == GameState.Playing)
        {
            updateScore = true;
        }
    }
}
