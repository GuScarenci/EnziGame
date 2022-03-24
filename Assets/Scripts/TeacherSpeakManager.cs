using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeacherSpeakManager : MonoBehaviour
{
    string[] teacherLine = {"Olá aluno! Esse é o EnziGame, use as teclas AWSD ou as setinhas para se locomover!",
    "No corpo agem várias enzimas, essas são responsáveis por acelerar as reações químicas que acontecem em nosso corpo.",
    "Uma enzima pode acelerar uma reação quimica em 10^6 até 10^12 vezes. As enzimas são diversas e com vários funcionamentos,nesse jogo vamos conhecer algumas",
    "das principais enzimas digestivas e o modelo chave-fechadura de funcionamento delas.",
    "CONTINUA"};
    public TMP_Text teacherText;
    public GameObject teacherPanel;
    int helper = 0;
    public SideSliderController sideSliderScript;
    public GameObject enzymeTimer; 
    // Start is called before the first frame update
    void Start()
    {
        teacherText.text = teacherLine[0];

        for(int i = 0;i<3;i++){
            sideSliderScript.HideSlider(i);
        }
        enzymeTimer.SetActive(false);
        

        //TIRAR DEPOIS//
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLine(){
        if(helper == 0){
            StartCoroutine(TeacherAwait());

        }else if(helper == 3){
            Time.timeScale = 1f;
            teacherPanel.SetActive(false);

            for(int i = 0;i<3;i++){
                sideSliderScript.ShowSlider(i);
            }
            enzymeTimer.SetActive(true);
            //GAMBIARRA

        }else{
            teacherText.text = teacherLine[helper+1];
        }
        helper++;
        Debug.Log(helper);
    }

    IEnumerator TeacherAwait(){
        Time.timeScale = 1f;

        teacherPanel.SetActive(false);

        //GAMBIARRA
        for(int i = 0;i<3;i++){
            sideSliderScript.ShowSlider(i);
        }
        enzymeTimer.SetActive(true);
        //GAMBIARRA

        yield return new WaitForSeconds(5);
        teacherPanel.SetActive(true);

        //GAMBIARRA

        for(int i = 0;i<3;i++){
            sideSliderScript.HideSlider(i);
        }

        enzymeTimer.SetActive(false);
        //GAMBIARRA

        Time.timeScale = 0f;
        teacherText.text = teacherLine[1];
    }
}
