using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeacherSpeakManager : MonoBehaviour
{
    string[] teacherLine = {"Olá aluno! Esse é o EnziGame, use as teclas AWSD ou as setinhas para se locomover!",
    "No corpo agem várias enzimas, essas são responsáveis por acelerar as reações químicas que acontecem em nosso corpo.",
    "Uma enzima pode acelerar uma reação quimica em 10^6 até 10^12 vezes. Elas são diversas e com vários tipos de funcionamentos.",
    "Nesse jogo vamos conhecer algumas das principais enzimas digestivas e o modelo chave-fechadura de funcionamento delas.",
    "A primeira fase do nosso jogo se passa na boca. A função dela na digestão dos alimentos é principalmente mecânico, lubrificante e de certo de controle de temperatura.",
    "Apesar disso, temos nela já algumas enzimas digestivas. Nela a principal enzima digestiva que temos é a Amilase salivar, que quebra polissacarídeos em maltose e glicose.",
    "As enzimas de modo geral aceleram a reação e quebram os substratos em produtos menores, cada enzima é extremamente específica ao seu substrato.",
    "Isso é chamado de modelo chave-fechadura. Devido ao encaixe único da enzima no seu substrato.",
    "Essa quebra é o começo de uma série de eventos que acontecerão a substância para que ela possa ser absorvida pelo nosso corpo.",
    "No Enzigame você controla uma enzima, e essas coisas navegando pela tela são os substratos.",
    "Perceba que elas tem um forma específica, vá atrás das que encaixam na enzima e quebre-as enconstando nelas.",
    "Assim você prepara as substâncias para serem quebradas por outras enzimas e outras coisas que vão vir a acontecer com elas...",
    "e equilibra os nutrientes do corpo (o que é mostrado na barra lateral) e ganha pontos."};
    public TMP_Text teacherText;
    public GameObject teacherPanel;
    int helper = 0;
    public SideSliderController sideSliderScript;
    public GameObject enzymeTimer; 

    void Start()
    {
        teacherText.text = teacherLine[0];

        for(int i = 0;i<3;i++){
            sideSliderScript.HideSlider(i);
        }
        enzymeTimer.SetActive(false);
        
        Time.timeScale = 0f;
    }

    void Update()
    {
        
    }
    public void ChangeLine(){
        if(helper == 0 || helper == 3){
            StartCoroutine(TeacherAwait(helper));

        }else if(helper == teacherLine.Length - 1){
            teacherPanel.SetActive(false);
            for(int i = 0;i<3;i++){
                sideSliderScript.ShowSlider(i);
            }
            Time.timeScale = 1f;
            enzymeTimer.SetActive(true);

        }else{
            teacherText.text = teacherLine[helper+1];
        }
        helper++;
        Debug.Log(helper);
    }

    IEnumerator TeacherAwait(int helper){
        Time.timeScale = 1f;

        teacherPanel.SetActive(false);

        for(int i = 0;i<3;i++){
            sideSliderScript.ShowSlider(i);
        }
        enzymeTimer.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        teacherPanel.SetActive(true);

        for(int i = 0;i<3;i++){
            sideSliderScript.HideSlider(i);
        }

        enzymeTimer.SetActive(false);

        Time.timeScale = 0f;
        teacherText.text = teacherLine[helper + 1];
    }
}
