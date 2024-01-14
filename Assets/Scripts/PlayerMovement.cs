using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private GridHandler gridHandler;

    public int inputCount;
    private bool upPressed, downPressed, leftPressed, rightPressed;
    private bool active;
    private Vector3 startingPos;

    private void Awake()
    {
        active = false;
        startingPos = new Vector3(0, 0, 0);
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
        transform.position = gridHandler.GetHere(startingPos);
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
                GameManager.instance.IncreaseScore(1);
                transform.position = gridHandler.GetUp(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(!downPressed)
            {
                downPressed = true;
                GameManager.instance.IncreaseScore(1);
                transform.position = gridHandler.GetDown(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(!leftPressed)
            {
                leftPressed = true;
                GameManager.instance.IncreaseScore(1);
                transform.position = gridHandler.GetLeft(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(!rightPressed)
            {
                rightPressed = true;
                GameManager.instance.IncreaseScore(1);
                transform.position = gridHandler.GetRight(transform.position);
                gridHandler.ColorPos(transform.position);
            }
        }
        
        if(upPressed && Input.GetKeyUp(KeyCode.UpArrow))
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

    private void OnStateChange(GameState newState)
    {
        active = false;
        if (newState == GameState.Playing)
        {
            active = true;
        }
    }
}
