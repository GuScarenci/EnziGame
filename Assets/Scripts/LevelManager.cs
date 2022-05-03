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
    public Sprite[] backgroundSprites;

    public GameObject bodyIndicative;
    public Sprite[] bodyIndicativeSprites;
    Image imageRenderer;


    public PlayerController playerScript;

    public TMP_Text levelText; 

    GameObject[,] background = new GameObject[40,40];
    int backgroundCount = 40;
    public GameObject backgroundPrefab;
    SpriteRenderer backgroundSpriteRenderer;

    public GameObject[] changePlayerButtons = new GameObject[3];

    void Start()
    {
        teacherScript = this.gameObject.GetComponent<TeacherSpeakManager>();
        for(int i = 0;i<backgroundCount;i++){
            for(int j = 0;j<backgroundCount;j++){
                background[i,j] = Instantiate(backgroundPrefab, new Vector3(i*20 -400, j*20 - 400, 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(1,5)*90)));
                backgroundSpriteRenderer = background[i,j].GetComponent<SpriteRenderer>();
                backgroundSpriteRenderer.sprite = backgroundSprites[0];
            }
        }

        imageRenderer = bodyIndicative.GetComponent<Image>();
    }

    void Update()
    {
        
    }

    public void PassLevel(){

        if(level == 0){

            playerScript.ChangePlayer(2);

            sliderScript.StopSliderCoroutine(0);
            sliderScript.HideSlider(0);

            sliderScript.CallSliderCoroutine(1);
            sliderScript.ShowSlider(1);


            teacherScript.ChangeLine();
            imageRenderer.sprite = bodyIndicativeSprites[1];
            
        }else if(level == 1){
            sliderScript.CallSliderCoroutine(0);
            sliderScript.ShowSlider(0);

            sliderScript.CallSliderCoroutine(2);
            sliderScript.ShowSlider(2);

            teacherScript.ChangeLine();
            
        }
        
        level++;
        teacherScript.level = level;
        playerScript.level = level;

        if(level == 1){
            levelText.text = "Estômago";
            backgroundSpriteRenderer.sprite = backgroundSprites[1];

            for(int i = 0;i<backgroundCount;i++){
                for(int j = 0;j<backgroundCount;j++){
                    backgroundSpriteRenderer = background[i,j].GetComponent<SpriteRenderer>();
                    backgroundSpriteRenderer.sprite = backgroundSprites[1];
                }
            }
        }else if(level == 2){
            levelText.text = "Intestino";
            imageRenderer.sprite = bodyIndicativeSprites[2];

            for(int i = 0;i<backgroundCount;i++){
                for(int j = 0;j<backgroundCount;j++){
                    backgroundSpriteRenderer = background[i,j].GetComponent<SpriteRenderer>();
                    backgroundSpriteRenderer.sprite = backgroundSprites[2];
                }
            }
            for(int i = 0;i<changePlayerButtons.Length;i++){
                changePlayerButtons[i].SetActive(true);
            }
        }
    }
}
