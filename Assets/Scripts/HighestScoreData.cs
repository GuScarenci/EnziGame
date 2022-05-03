using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighestScoreData{
    public int highestScore;

    public HighestScoreData (ScoreManager scoreScript){
        highestScore = scoreScript.score;
    }
}
