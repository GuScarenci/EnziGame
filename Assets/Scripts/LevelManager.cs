using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int level;
    TeacherSpeakManager teacherScript;
    public SideSliderController sliderScript;
    public Sprite[] backGroundSprite;


    public PlayerController playerScript;

    public TMP_Text levelText; 

    GameObject[,] background = new GameObject[40,40];
    int backgroundCount = 40;
    public GameObject backgroundPrefab;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        teacherScript = this.gameObject.GetComponent<TeacherSpeakManager>();
        for(int i = 0;i<backgroundCount;i++){
            for(int j = 0;j<backgroundCount;j++){
                background[i,j] = Instantiate(backgroundPrefab, new Vector3(i*20 -100, j*20 - 100, 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(1,5)*90)));
                spriteRenderer = background[i,j].GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = backGroundSprite[0];
            }
        }
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

            for(int i = 0;i<backgroundCount;i++){
                for(int j = 0;j<backgroundCount;j++){
                    spriteRenderer = background[i,j].GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = backGroundSprite[1];
                }
            }
            
        }else if(level == 1){
            sliderScript.ShowSlider(0);
            sliderScript.CallSliderCoroutine(0);

            sliderScript.ShowSlider(2);
            sliderScript.CallSliderCoroutine(2);

            teacherScript.ChangeLine();

            for(int i = 0;i<backgroundCount;i++){
                for(int j = 0;j<backgroundCount;j++){
                    spriteRenderer = background[i,j].GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = backGroundSprite[2];
                }
            }
        }
        
        level++;
        teacherScript.level = level;
        playerScript.level = level;
        if(level == 1){
            levelText.text = "Estômago";
        }else if(level == 2){
            levelText.text = "Intestino";
        }
    }
}
