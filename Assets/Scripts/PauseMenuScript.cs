using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    TeacherSpeakManager teacherScript;
    public SideSliderController sliderScript;

    public GameObject pauseMenuUI;

    public GameObject pauseButton;

    void Start(){
        Time.timeScale = 1f;
        teacherScript = this.GetComponent<TeacherSpeakManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                if(sliderScript.lostTheGame != true){
                    Resume();
                }
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
            if(teacherScript.pausedByTeacher != true){
                Time.timeScale = 1f;
            }
        GameIsPaused = false;
    }
    public void Pause(){
        pauseButton.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
