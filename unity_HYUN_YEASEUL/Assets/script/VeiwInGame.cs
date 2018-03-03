using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//InGameCanvas의 내용을 나타내기 위한 Script(17.11.11)
public class VeiwInGame : MonoBehaviour
{   
    //unity inspector 값 대입
    public Text scoreLabel;
    public Text coinLabel;
    //player controller public void kill
    public Text highscoreLabel;

    void Update()
    {
     if(GameManager.instance.currentGameState == GameState.inGame)
        {
            scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
            coinLabel.text = GameManager.instance.collectedCoins.ToString();
            highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }
}
