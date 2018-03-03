using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{   
    
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;

    //콜렉터블(17.11.11) 
    //collectable.cs를 call하는 public 함수
    public int collectedCoins = 0;
    public void CollectedCoin()
    {
        collectedCoins++;
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGameState = GameState.menu;
    }

    //called to start the game
    public void StartGame()
    {
        PlayerController.instance.StartGame();
        BackgroundScroller.instance.Start();
        LevelGenerator.instance.Start();
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }
    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //setup Unity scene for menu state
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            //setup Unity scene for gameOver state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            //setup Unity scene for gameOver state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }
        currentGameState = newGameState;
    }
    void Update()
    {
        if (Input.GetButton("s"))
            StartGame();
    }
}       
     