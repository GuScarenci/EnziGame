using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int level;
    TeacherSpeakManager teacherScript;
    public SideSliderController sliderScript; 

    void Start()
    {
        teacherScript = this.gameObject.GetComponent<TeacherSpeakManager>();
    }

    void Update()
    {
        
    }

    public void PassLevel(){
        if(level == 0){
            sliderScript.ShowSlider(1);
            sliderScript.CallSliderCoroutine(1);
            
        }else if(level == 1){
            sliderScript.ShowSlider(2);
            sliderScript.CallSliderCoroutine(2);
        }
        level++;
    }
}
