using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventLauncher : MonoBehaviour
{
    public GameObject destroyer;
    public GameObject textPH;
    public TeacherSpeakManager teacherScript;
    public GameObject textTemperature;

    bool hasCalledTeacher = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (PHEvent());
        StartCoroutine (TemperatureEvent());

    }

    IEnumerator PHEvent(){
        while(true){
            bool started = false;
            if(!started){
                yield return new WaitForSeconds(5);
            }
            int temp = Random.Range(0,10);
            if (temp == 1){
                if(hasCalledTeacher){
                    teacherScript.ChangeLine();
                }
                destroyer.GetComponent<DestroyerScript>().increaseDestroyDelay();
                textPH.SetActive(true);
            }
            yield return new WaitForSeconds(5);
            if(temp == 1){
                destroyer.GetComponent<DestroyerScript>().reduceDestroyDelay();
                textPH.SetActive(false);
            }
        }
    }

    IEnumerator TemperatureEvent(){
        while(true){

            yield return new WaitForSeconds(10);

            int temp = Random.Range(0,10);
            if (temp == 1){
                destroyer.GetComponent<DestroyerScript>().increaseDestroyDelay();
                textTemperature.SetActive(true);
            }
            yield return new WaitForSeconds(5);
            if(temp == 1){
                destroyer.GetComponent<DestroyerScript>().reduceDestroyDelay();
                textTemperature.SetActive(false);
            }
        }


    }
}
