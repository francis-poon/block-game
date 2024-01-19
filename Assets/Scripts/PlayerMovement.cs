using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private GridHandler gridHandler;

    public int inputCount;
    private bool upPressed, downPressed, leftPressed, rightPressed;
    private bool active;
    private Vector3 startingPos;
    private Vector3 previousPos;

    private void Awake()
    {
        active = false;
        inputCount = 0;
        upPressed = false;
        downPressed = false;
        leftPressed = false;
        rightPressed = false;
        GameManager.onAfterStateChanged += OnStateChange;

    }

    private void OnDestroy()
    {
        GameManager.onAfterStateChanged -= OnStateChange;
    }

    private void Start()
    {
        gridHandler = GameManager.instance.levelGrid.GetComponent<GridHandler>();
        startingPos = GameData.levels[GameManager.instance.currentLevel].startingPos;
        transform.position = gridHandler.GetHere(startingPos);
        previousPos = transform.position;
        gridHandler.ColorPos(transform.position);
    }

    private void Update()
    {
        if(!active) { return; }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!upPressed)
            {
                upPressed = true;
                transform.position = gridHandler.GetUp(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(!downPressed)
            {
                downPressed = true;
                transform.position = gridHandler.GetDown(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(!leftPressed)
            {
                leftPressed = true;
                transform.position = gridHandler.GetLeft(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(!rightPressed)
            {
                rightPressed = true;
                transform.position = gridHandler.GetRight(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }

        CheckIncreaseScore();
        previousPos = transform.position;

        if (upPressed && Input.GetKeyUp(KeyCode.UpArrow))
        {
            upPressed = false;
        }
        if(downPressed && Input.GetKey(KeyCode.DownArrow))
        {
            downPressed = false;
        }
        if(leftPressed && Input.GetKey(KeyCode.LeftArrow))
        {
            leftPressed = false;
        }
        if(rightPressed && Input.GetKey(KeyCode.RightArrow))
        {
            rightPressed = false;
        }
    }

    private void CheckIncreaseScore()
    {
        if ((transform.position - previousPos).magnitude > 0.1)
        {
            GameManager.instance.IncreaseScore(1);
        }
    }

    private void OnStateChange(GameState newState)
    {
        active = false;
        if (newState == GameState.Playing)
        {
            active = true;
        }
    }
}
