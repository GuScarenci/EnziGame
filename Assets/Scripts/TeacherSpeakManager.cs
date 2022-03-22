using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeacherSpeakManager : MonoBehaviour
{
    string[] teacherLine = {"Olá aluno!" , "Enzimas são legais!"};
    public TMP_Text teacherText;
    int helper = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLine(){
        if(helper == 1){
            teacherText.text = teacherLine[0];
            helper = 0;
        }else{
            teacherText.text =  teacherLine [1];
            helper = 1;
        }
    }
}
