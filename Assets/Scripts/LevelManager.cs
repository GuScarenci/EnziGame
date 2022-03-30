using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    int level;

    public GameObject um;
    public GameObject dois;
    TeacherSpeakManager teacherScript;
    public SideSliderController sliderScript;

    public PlayerController playerScript;

    public TMP_Text levelText; 

    void Start()
    {
        teacherScript = this.gameObject.GetComponent<TeacherSpeakManager>();
    }

    void Update()
    {
        
    }

    public void PassLevel(){
        if(level == 0){

            playerScript.ChangePlayer(2);

            sliderScript.HideSlider(0);
            sliderScript.StopSliderCoroutine(0);

            sliderScript.ShowSlider(1);
            sliderScript.CallSliderCoroutine(1);

            teacherScript.ChangeLine();

            um.SetActive(false);
            
        }else if(level == 1){
            sliderScript.ShowSlider(0);
            sliderScript.CallSliderCoroutine(0);

            sliderScript.ShowSlider(2);
            sliderScript.CallSliderCoroutine(2);

            teacherScript.ChangeLine();

            dois.SetActive(false);
        }
        
        level++;
        teacherScript.level = level;
        playerScript.level = level;
        levelText.text = "Fase " + (level + 1);
    }
}
