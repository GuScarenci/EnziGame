using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventLauncher : MonoBehaviour
{
    public GameObject destroyer;
    public GameObject[] textPHAndTemperature;
    public TeacherSpeakManager teacherScript;

    void Start()
    {
        StartCoroutine (StartPHAndTemperature());
    }

    IEnumerator StartPHAndTemperature(){
        yield return new WaitForSeconds(12);
        for(int i = 0;i<2;i++){
            textPHAndTemperature[i].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PHTempOn");
            destroyer.GetComponent<DestroyerScript>().increaseDestroyDelay();
        }
        teacherScript.ChangeLine();

        yield return new WaitForSeconds(5);

        for(int i = 0;i<2;i++){
            textPHAndTemperature[i].SetActive(false);
            FindObjectOfType<AudioManager>().Play("PHTempOff");
            destroyer.GetComponent<DestroyerScript>().reduceDestroyDelay();
        }
        
        for(int i = 0;i<2;i++){
            StartCoroutine (PHAndTemperatureEvent(i));  
        }
    }

    IEnumerator PHAndTemperatureEvent(int phOrTemperature){
        while(true){

            int temp = Random.Range(0,10);
            if (temp == 1){
                destroyer.GetComponent<DestroyerScript>().increaseDestroyDelay();
                textPHAndTemperature[phOrTemperature].SetActive(true);
                FindObjectOfType<AudioManager>().Play("PHTempOn");
            }
            yield return new WaitForSeconds(5);
            if(temp == 1){
                destroyer.GetComponent<DestroyerScript>().reduceDestroyDelay();
                textPHAndTemperature[phOrTemperature].SetActive(false);
                FindObjectOfType<AudioManager>().Play("PHTempOff");
            }
        }
    }
}
