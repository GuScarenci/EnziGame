using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeacherSpeakManager : MonoBehaviour
{
    /*0*/string[] teacherLine = {"Olá aluno! Esse é o EnziGame, use as teclas AWSD ou as setinhas para se locomover!",
    /*Intervalo 1*/"No corpo agem várias enzimas, essas são responsáveis por acelerar as reações químicas que acontecem em nosso corpo.",
    "Uma enzima pode acelerar uma reação quimica em 10^6 até 10^12 vezes. Elas são diversas e com vários tipos de funcionamentos.",
    /*Intervalo 3*/"Nesse jogo vamos conhecer algumas das principais enzimas digestivas e o modelo chave-fechadura de funcionamento delas.",
    /*4*/"A primeira fase do nosso jogo se passa na boca. A função dela na digestão dos alimentos é principalmente mecânico, lubrificante e de certo de controle de temperatura.",
    "Apesar disso, temos nela já algumas enzimas digestivas. Nela a principal enzima digestiva que temos é a Amilase salivar, que quebra polissacarídeos em maltose e glicose.",
    "As enzimas de modo geral aceleram a reação e quebram os substratos em produtos menores, cada enzima é extremamente específica ao seu substrato.",
    "Isso é chamado de modelo chave-fechadura. Devido ao encaixe único da enzima no seu substrato.",
    "Essa quebra é o começo de uma série de eventos que acontecerão a substância para que ela possa ser absorvida pelo nosso corpo.",
    "No Enzigame você controla uma enzima, e essas coisas navegando pela tela são os substratos.",
    "Perceba que elas tem um forma específica, vá atrás das que encaixam na enzima e quebre-as enconstando nelas.",
    "Assim você prepara as substâncias para serem quebradas por outras enzimas e outras coisas que vão vir a acontecer com elas...",
    /*Some 12*/"e equilibra os nutrientes do corpo (o que é mostrado na barra lateral) e ganha pontos.",
    "",
    /*Aparece 13*/"As enzimas trabalham em um ph e temperatura ideias. Portanto uma enzima fora de seu ph ou temperatura ideal irá trabalhar mais devagar.",
    "No Enzigame, eventualmente o ph e a temperatura são alterados, isso pode significar...",
    "que a pessoa ingeriu algo que alterou o ph dentro de determinado orgão ou que está com febre, por exemplo.",
    /*Intervalo 16*/"A enzima trabalhar mais devagar irá dificultar a regulação do corpo. Lembrando que se alguma barra esvazia totalmente o jogo é perdido!",
    /*Some 17*/"Consiga 10 pontos sem deixar que a barra lateral fique vazia para passsar de fase!",
    "",
    /*Aparece 18*/"Parabéns você passou de fase! Agora saímos da boca e vamos para o estômago.",
    "No estômago, os alimentos que passaram pela boca são misturados e acidificados.",
    "Algumas enzimas entram em ação, a principal enzima digestiva que age no estômago é a pepsina...",
    /*21*/"Essa enzima quebra as proteínas em partes menores que futuramente serão quebradas em partes ainda menores por outras enzimas.",
    "",
    "No intestino delgado, muitas enzimas entram em ação, enzimas que quebram lipídios, carboidratos, proteínas etc. Algumas dessas enzimas são produzidas pelo pâncreas...",
    "e aqui finalmente estamos perto de onde a maioria dos nutrientes é absorvida pelo corpo humano.",
    "No Enzigame aqui é ultima fase, aperte os botões \"E R T\" para transitar entre as 3 enzimas existentes e quebrar os substratos, aqui você...",
    "precisará equilibrar as 3 barras de nutrientes, então lembre-se de não deixar nenhuma delas zerar. Mude para a enzima necessária...",
    "quando a barra respectiva a ela estiver perto de 0 para não perder o jogo!"};
    public TMP_Text teacherText;
    public GameObject teacherPanel;
    int helper = 0;
    public int level = 0;
    public SideSliderController sideSliderScript;
    public GameObject enzymeTimer; 

    void Start()
    {
        teacherText.text = teacherLine[helper];
        helper++;

        ShowTeacher();
        
        Time.timeScale = 0f;
    }

    void Update()
    {
        
    }
    public void ChangeLine(){
        /*INTERVALO*/if(helper == 1 || helper == 4){
            StartCoroutine(TeacherAwait(helper));
            helper++;

        /*APARECE*/}else if(helper == 14 || helper == 20 || helper == 25){
            Time.timeScale = 0f;
            ShowTeacher();
            teacherText.text = teacherLine[helper];
            helper++;

        /*SOME*/}else if(helper == teacherLine.Length || helper == 13 || helper == 19 || helper == 24){
            HideTeacher();
            Time.timeScale = 1f;
            helper++;

        }else{
            teacherText.text = teacherLine[helper];
            helper++;
        }
        Debug.Log(helper);
    }

    IEnumerator TeacherAwait(int helper){
        Time.timeScale = 1f;

        HideTeacher();

        yield return new WaitForSeconds(3f);
        
        ShowTeacher();

        Time.timeScale = 0f;
        teacherText.text = teacherLine[helper];
    }

    public void ShowTeacher(){
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
