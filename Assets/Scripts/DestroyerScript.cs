using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestroyerScript : MonoBehaviour
{
    public Slider enzymeTimer;
    public GameObject slidersController; 

    public ScoreManager scoreManagerScript;

    public int timeEnzyme;
    public int numberOfEnzymeBarSubtractions;

    void OnTriggerStay2D(Collider2D other){
        DestroyObjects(other.gameObject);
    }

    void DestroyObjects(GameObject other){
        float angleZ = Quaternion.Angle(Quaternion.Euler(new Vector3(0,0,0)),this.transform.rotation);
        float angleZOther = Quaternion.Angle(Quaternion.Euler(new Vector3(0,0,0)),other.transform.rotation);

        if (other.gameObject.CompareTag("Substrate")){
            if(this.gameObject.transform.parent.GetComponent<PlayerController>().type == other.gameObject.GetComponent<SubstrateController>().type){
                if(angleZ + angleZOther > 155 && angleZ + angleZOther <205){
                    StartCoroutine(EnzymeTimer(other));
                    FindObjectOfType<AudioManager>().Play("SubstrateAcquisition");
                }
            }
        }
    }
    
    IEnumerator EnzymeTimer(GameObject other){

        this.gameObject.transform.parent.GetComponent<PlayerController>().ChangePlayer(-1);

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false; 

        other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        other.gameObject.GetComponent<SpriteRenderer>().enabled = false; 
        
        //StartCoroutine(EnzymeTimeBarAnimation());

        //yield return new WaitForSeconds(timeEnzyme);

        float timeOfEachSubtratction = (float)timeEnzyme/numberOfEnzymeBarSubtractions;
        float valueOfEachSubstraction = (float)1/numberOfEnzymeBarSubtractions;

        for(int i = 0;i<=numberOfEnzymeBarSubtractions;i++){
            yield return new WaitForSeconds(timeOfEachSubtratction);
            enzymeTimer.value -= valueOfEachSubstraction;
        }

        enzymeTimer.value = 1;

        FindObjectOfType<AudioManager>().Play("SubstrateDestruction");
        
        other.GetComponent<SubstrateController>().DestructionEffect();

        other.GetComponent<SubstrateController>().RemoveShip();

        this.gameObject.transform.parent.GetComponent<PlayerController>().ChangePlayer(-2);

        scoreManagerScript.AddScore();

        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        slidersController.GetComponent<SideSliderController>().addFill(this.transform.parent.GetComponent<PlayerController>().type);

    }

    IEnumerator EnzymeTimeBarAnimation(){
        float timeOfEachSubtratction = (float)timeEnzyme/numberOfEnzymeBarSubtractions;
        float valueOfEachSubstraction = (float)1/numberOfEnzymeBarSubtractions;

        for(int i = 0;i<=numberOfEnzymeBarSubtractions;i++){
            yield return new WaitForSeconds(timeOfEachSubtratction);
            enzymeTimer.value -= valueOfEachSubstraction*1.1f;
        }

        enzymeTimer.value = 1;
    }

    public void reduceDestroyDelay(){
        timeEnzyme -= 2;
    }
    
    public void increaseDestroyDelay(){
        timeEnzyme += 2;
    }
}
