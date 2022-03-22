using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyerScript : MonoBehaviour
{
    public Text scoreText;
    int score;
    public Slider enzymeTimer;
    public GameObject slidersController;
    public float destroyingDelay = 0.00001f; 
    void Start()
    {
    }
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        DestroyObjects(other);
    }

    void DestroyObjects(Collision2D other){
        float angleZ = Quaternion.Angle(Quaternion.Euler(new Vector3(0,0,0)),this.transform.parent.rotation);
        float angleZOther = Quaternion.Angle(Quaternion.Euler(new Vector3(0,0,0)),other.transform.rotation);

        if (other.gameObject.CompareTag("Substrate")){
            Debug.Log(angleZ + angleZOther);
            if(this.gameObject.transform.parent.GetComponent<PlayerController>().type == other.gameObject.GetComponent<SubstrateController>().type){
                if(angleZ + angleZOther > 170 && angleZ + angleZOther <190){
                    StartCoroutine(EnzymeTimer(other));
                }
            }
        }
    }
    
    IEnumerator EnzymeTimer(Collision2D other){

        this.gameObject.transform.parent.GetComponent<PlayerController>().ChangePlayer(-1);

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;  

        Destroy(other.gameObject.GetComponent<BoxCollider2D>());    // <------ GAMBIARRA
        Destroy(other.gameObject.GetComponent<SpriteRenderer>());   // <------ GAMBIARRA

        while(enzymeTimer.value > 0){
            yield return new WaitForSeconds (destroyingDelay * Time.deltaTime);
            enzymeTimer.value -= 0.003f;
        }

        other.gameObject.GetComponent<SubstrateController>().DestructionEffect();
        other.gameObject.GetComponent<SubstrateController>().RemoveShip(); // <------ GAMBIARRA

        enzymeTimer.value = 1;
        score++;
        scoreText.text = "Pontos:" + score;

        this.gameObject.transform.parent.GetComponent<PlayerController>().ChangePlayer(-2);

        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        slidersController.GetComponent<SideSliderController>().addFill(this.transform.parent.GetComponent<PlayerController>().type);

    }

    public void reduceDestroyDelay(){
        destroyingDelay -= 0.02f * Time.deltaTime;
    }
    
    public void increaseDestroyDelay(){
        destroyingDelay += 0.02f * Time.deltaTime;
    }
}
