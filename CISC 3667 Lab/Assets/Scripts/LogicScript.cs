using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerScore;
    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int score) {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }
}
