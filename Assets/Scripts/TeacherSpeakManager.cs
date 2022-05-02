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
    "e equilibra os nutrientes do corpo (o que é mostrado na barra lateral) e ganha pontos.",
    "Consiga 10 pontos sem deixar que a barra lateral fique vazia para passsar de fase!",

    "As enzimas trabalham em um ph e temperatura ideias. Portanto uma enzima fora de seu ph ou temperatura ideal irá trabalhar mais devagar.",
    "No Enzigame, eventualmente o ph e a temperatura são alterados, isso pode significar...",
    "que a pessoa ingeriu algo que alterou o ph dentro de determinado orgão ou que está com febre, por exemplo.",
    "A enzima trabalhar mais devagar irá dificultar a regulação do corpo. Lembrando que se alguma barra esvazia totalmente o jogo é perdido!",

    "Parabéns você passou de fase! Agora saímos da boca e vamos para o estômago.",
    "No estômago, os alimentos que passaram pela boca são misturados e acidificados.",
    "Algumas enzimas entram em ação, a principal enzima digestiva que age no estômago é a pepsina...",
    "Essa enzima quebra as proteínas em partes menores que futuramente serão quebradas em partes ainda menores por outras enzimas.",

    "Parabéns você passou de fase! Agora saímos do estômago e vamos para a boca",
    "No intestino delgado, muitas enzimas entram em ação, enzimas que quebram lipídios, carboidratos, proteínas etc. Algumas dessas enzimas são produzidas pelo pâncreas...",
    "e aqui finalmente estamos perto de onde a maioria dos nutrientes é absorvida pelo corpo humano.",
    "No Enzigame aqui é ultima fase, aperte os botões \"E R T\" para transitar entre as 3 enzimas existentes e quebrar os substratos, aqui você...",
    "precisará equilibrar as 3 barras de nutrientes, então lembre-se de não deixar nenhuma delas zerar. Mude para a enzima necessária...",
    "quando a barra respectiva a ela estiver perto de 0 para não perder o jogo!"};
    public TMP_Text teacherText;
    public GameObject teacherPanel;
    
    int teacherSpeakIndex = 0;
    public int level = 0;
    public SideSliderController sideSliderScript;
    public GameObject enzymeTimer; 

    public bool pausedByTeacher = false;
    int helper = -1;

    public GameObject playerController;
     public GameObject playerController2;

    void Start()
    {
        teacherText.text = teacherLine[teacherSpeakIndex];
        ShowTeacher();
        Time.timeScale = 0f;
        pausedByTeacher = true;
    }

    public void ChangeLine(){
            //Debug.Log(teacherSpeakIndex);
            /*INTERVALO*/if(teacherSpeakIndex == 0 || teacherSpeakIndex == 3 || teacherSpeakIndex == 8){
                teacherSpeakIndex++;
                StartCoroutine(TeacherAwait(teacherSpeakIndex));
                teacherText.text = teacherLine[teacherSpeakIndex];

            /*SOME*/}else if(teacherSpeakIndex == teacherLine.Length || teacherSpeakIndex == 13 || teacherSpeakIndex == 17 || teacherSpeakIndex == 21){

                if(helper == -1){
                    HideTeacher();
                    Time.timeScale = 1f;
                    pausedByTeacher = false;
                    //Debug.Log(helper);
                }else{
                    ShowTeacher();
                    Time.timeScale = 0f;
                    pausedByTeacher = true;
                    teacherSpeakIndex++;
                    teacherText.text = teacherLine[teacherSpeakIndex];
                }
                helper *= -1;

            }else{
                teacherSpeakIndex++;
                teacherText.text = teacherLine[teacherSpeakIndex];
            }
    }

    IEnumerator TeacherAwait(int teacherSpeakIndex){

        Time.timeScale = 1f;
        pausedByTeacher = false;

        HideTeacher();

        yield return new WaitForSeconds(3f);
        
        ShowTeacher();

        Time.timeScale = 0f;
        pausedByTeacher = true;
    }

    public void ShowTeacher(){
        playerController.SetActive(false);
        playerController2.SetActive(false);

        teacherPanel.SetActive(true);

        if(level == 0){
            sideSliderScript.HideSlider(0);
        }else if(level == 1){
            sideSliderScript.HideSlider(1);
        }else if(level == 2){
            for(int i = 0;i<level + 1;i++){
                sideSliderScript.HideSlider(i);
            }
        }
        enzymeTimer.SetActive(false);
    }

    public void HideTeacher(){
        playerController.SetActive(true);
        playerController2.SetActive(true);

        teacherPanel.SetActive(false);
        if(level == 0){
            sideSliderScript.ShowSlider(0);
        }else if(level == 1){
            sideSliderScript.ShowSlider(1);
        }else if(level == 2){
            for(int i = 0;i<level + 1;i++){
                sideSliderScript.ShowSlider(i);
            }
        }
        enzymeTimer.SetActive(true);
    }
}
