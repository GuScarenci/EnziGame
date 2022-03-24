using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    int score;

    public LevelManager levelManagerScript;

    void Start()
    {
    }
    void Update()
    { 
    }

    public void AddScore(){
        score++;
        scoreText.text = "Pontos:" + score;
        if(score >= 5){
            levelManagerScript.PassLevel();
        }
    }
}
