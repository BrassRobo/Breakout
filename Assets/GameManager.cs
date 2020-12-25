using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    private int score=0;
    private int lives = 3;
    public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        AddToScore(0);
        AddToLives(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
    public void AddToLives(int value)
    {
        lives += value;
        livesText.text = "Lives: " + lives;
    }
    public void LoseALife(BallController ball)
    {
        AddToLives(-1);
        if (lives < 1)
        {
            GameOver();
        }
        else
        {
            ball.destroyBall();
            Instantiate(ballPrefab, new Vector3(0.01632249f, 2.535f, 0), Quaternion.identity);
        }
    }
    
    public void GameOver()
    {
        //Game Over Screen
    }

}
