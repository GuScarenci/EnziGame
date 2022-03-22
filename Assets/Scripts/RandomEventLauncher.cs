using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventLauncher : MonoBehaviour
{
    public GameObject destroyer;
    public GameObject textPH;
    public GameObject textTemperature;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (PHEvent());
        StartCoroutine (TemperatureEvent());

    }

    IEnumerator PHEvent(){
        while(true){
            int temp = Random.Range(0,10);
            if (temp == 1){
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
