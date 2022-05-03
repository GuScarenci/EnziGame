using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highestScoreText;
    public int score;
    public int highestScore;
    public LevelManager levelManagerScript;

    void Start()
    {
        LoadScore();
    }
    void Update()
    { 
        if (!(SceneManager. GetActiveScene () == SceneManager. GetSceneByName ("Menu"))){
            if(Input.GetKeyDown("i")){
                AddScore();
            }
        }
    }

    public void AddScore(){
        score++;
        scoreText.text = "Pontos:" + score;
        if(score == 10){
            levelManagerScript.PassLevel();
        }else if (score == 20){
            levelManagerScript.PassLevel();
        }
    }

    public void SaveScore(){
        if(score > highestScore){
            SaveSystem.SavePlayer(this);
        }
    }
    public void LoadScore(){
        HighestScoreData data = SaveSystem.LoadPlayer();
        highestScore = data.highestScore;
        if ((SceneManager. GetActiveScene () == SceneManager. GetSceneByName ("Menu"))){
            highestScoreText.text = "Maior Pontuação:" + highestScore;
        }
    }
}
